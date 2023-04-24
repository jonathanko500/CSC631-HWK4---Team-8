using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResponseScoreEventArgs : ExtendedEventArgs
{
	public int user_id { get; set; } // The user_id of whom who sent the request
	public int piece_idx { get; set; } // The index of the piece to Score. Belongs to player with id user_id
	public int x { get; set; } // The x coordinate of the target location
	public int y { get; set; } // The y coordinate of the target location
	public int score { get; set; } // what the score was

	public ResponseScoreEventArgs()
	{
		event_id = Constants.SMSG_SCORE;
	}
}

public class ResponseScore : NetworkResponse
{
	private int user_id;
	private int piece_idx;
	private int x;
	private int y;
	private int score;

	public ResponseScore()
	{
	}

	public override void parse()
	{
		user_id = DataReader.ReadInt(dataStream);
		piece_idx = DataReader.ReadInt(dataStream);
		x = DataReader.ReadInt(dataStream);
		y = DataReader.ReadInt(dataStream);
		score = DataReader.ReadInt(dataStream);
	}

	public override ExtendedEventArgs process()
	{
		ResponseScoreEventArgs args = new ResponseScoreEventArgs
		{
			user_id = user_id,
			piece_idx = piece_idx,
			x = x,
			y = y,
      score = score
		};

		return args;
	}
}
