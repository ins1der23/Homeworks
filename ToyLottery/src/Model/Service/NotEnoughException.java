package Model.Service;


/**
 * Исключение, выбрасываемое в случае малого количества призов
 */
public class NotEnoughException extends RuntimeException {
   
    public NotEnoughException() {
        super("Not enough prizes or too much participants");
    }
   
    public NotEnoughException(String message) {
        super(message);
    }

}
