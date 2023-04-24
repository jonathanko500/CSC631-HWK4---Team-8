package networking.request;

// Java Imports
import java.io.IOException;

// Other Imports
import model.Player;
import networking.response.ResponseSpawn;
import utility.DataReader;
import core.NetworkManager;

public class RequestSpawn extends GameRequest {
    private int gameBoardX,gameBoardY;
    // Responses
    private ResponseScore responseSpawn;

    public RequestSpawn() {
        responses.add(responseSpawn = new ResponseSpawn());
    }

    @Override
    public void parse() throws IOException {

        gameBoardX = DataReader.readInt(dataInput);
        gameBoardY = DataReader.readInt(dataInput);

    }

    @Override
    public void doBusiness() throws Exception {
        Player player = client.getPlayer();

        responseSpawn.setPlayer(player);
        responseSpawn.setData();
        NetworkManager.addResponseForAllOnlinePlayers(player.getID(), responseSpawn);
    }
}