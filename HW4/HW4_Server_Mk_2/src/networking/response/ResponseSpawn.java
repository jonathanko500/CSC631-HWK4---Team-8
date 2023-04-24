package networking.response;

// Other Imports
import metadata.Constants;
import model.Player;
import utility.GamePacket;
import utility.Log;
/**
 * The ResponseLogin class contains information about the authentication
 * process.
 */
public class ResponseSpawn extends GameResponse {
    private Player player;
    private int gameBoardX,gameBoardY;

    public ResponseSpawn() {
        responseCode = Constants.SMSG_SPAWN;
    }

    @Override
    public byte[] constructResponseInBytes() {
        GamePacket packet = new GamePacket(responseCode);
        packet.addInt32(player.getID());

        packet.addInt32(gameBoardX);
        packet.addInt32(gameBoardY);


        Log.printf("Player with id %d has Scored: %d", player.getID());

        return packet.getBytes();
    }

    public void setPlayer(Player player) {
        this.player = player;
    }

    public void setData(int gameBoardX, int gameBoardY) {
        this.gameBoardX = gameBoardX;
        this.gameBoardY = gameBoardY;
    }
}