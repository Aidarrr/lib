#include <QWidget>
#include <QLineEdit>
#include <QLabel>
#include <QPushButton>
#include <QTableWidget>

class GameWidget : public QWidget {     //Класс для основной логики игры
  Q_OBJECT
public:
  explicit GameWidget(QWidget *parent = nullptr);

private slots:              //Функции, использующиеся при нажатии на кнопки
  void gameStart();
  void gameStop();
  void makeMove();
  void readPersonNumber();

private:
  void calcBullsAndCows(QString input, QString original, int& nCows, int& nBulls);
  bool isValidNumber(int number, QString sNumber);      //Проверка введенного числа
  void computerMove();                                  //Алгоритм ходов компьютера
  QString getRandomNumberWithUniqueDigits();            //Загадывание числа компьютером
  bool isCharRepeated(QString sNumber, QChar charDigit);
  void initializeCompArray();                           //Инициализация массива для алгоритма ходов компьютера
  bool isConvenientGuessArrayNumber(QString guessNumber, QString currentMoveNum, int nCows, int nBulls); //Исключение чисел, возможных для ответа компьютером

private:
  QLineEdit numberInput;    //Поле для ввода числа
  QLabel statusMessage;
  QPushButton checkButton;  //Кнопка для совершения хода
  QPushButton readNumButton;//Кнопка для загадывания числа
  QTableWidget table;       //Таблица ходов человека
  QTableWidget ai_table;    //Таблица ходов компьютера
  QString computerNumber;
  QString personNumber;
  QString partlyOpenedCompNumber;
  QLabel labelCompNumber;
  int numberLength = 4;
  bool personWon;
  bool computerWon;
  bool compFirstMove;
  bool isLowDifficult;
  bool isCompMove;
  int maxCompArraySize = 9000;
  QVector<QString> compGuesses; //Массив возможных ответов компьютера
  QVector<bool> compMarkedGuesses;
};

