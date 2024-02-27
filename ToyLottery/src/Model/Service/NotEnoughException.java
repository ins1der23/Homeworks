package Model.Service;

public class NotEnoughException extends RuntimeException {
   
    public NotEnoughException() {
        super("Not enough prizes or too much participants");
    }
   
    public NotEnoughException(String message) {
        super(message);
    }

}
