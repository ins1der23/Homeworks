package View.Interfaces;

public interface iUiText {
     /**
      * @return Текст главного меню
      */
     String[] mainMenu();

     /**
      * @return Текст для выбора варианта
      */
     String chooseOption();

     /**
      * @return Текст для выбора типа приза
      */
     String chooseType();

     /**
      * @return Текст для типов приза
      */
     String[] prizeTypes();

     /**
      * @return Текст для ввода наменования приза
      */
     String toyName();

     /**
      * @return Текст для ввода количества участников
      */
     String participants();

     /**
      * @return Текст для ввода количества выдваемых призов
      */
     String prizeCount();

     /**
      * @return Текст для ввода количества разыгрваемых игрушек
      */
     String toysCount();

     /**
      * @return Текст для паузы
      */
     String pause();

     /**
      * @return Заголовок списка разыгрываемых игрушек
      */
     String toysHeader();

     /**
      * 
      * @return Заголовок списка результатов
      */
     String resultsHeader();

     /**
      * @return Заголовок списка выданных призов
      */
     String prizesHeader();

     /**
      * @return Текст ошибки ввода
      */
     String inputError();
}
