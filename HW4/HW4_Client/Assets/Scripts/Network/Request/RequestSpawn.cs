using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequestSpawn : NetworkRequest
{
	public RequestSpawn()
	{
		request_id = Constants.CMSG_SPAWN;
	}

	public void send(int gameBoardX, int gameBoardY)
	{
		packet = new GamePacket(request_id);		
		packet.addInt32(gameBoardX);
		packet.addInt32(gameBoardY);		
	}
}
