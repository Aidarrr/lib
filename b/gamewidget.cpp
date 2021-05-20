#include "gamewidget.h"
#include <QGridLayout>
#include <QHeaderView>
#include <QInputDialog>
#include <QMessageBox>

GameWidget::GameWidget(QWidget *parent)
  : QWidget(parent),
    checkButton("Проверить", this),
    readNumButton("Загадать", this),
    table(0, 3, this),
    ai_table(0, 3, this),
    compGuesses(maxCompArraySize, QString(numberLength)),
    compMarkedGuesses(maxCompArraySize, true){

  setWindowTitle("Быки и коровы");
  personWon = false;
  computerWon = false;
  compFirstMove = true;

  initializeCompArray();

  QGridLayout *layout = new QGridLayout(this);
  this->setLayout(layout);

  auto startButton = new QPushButton("Новая игра", this);
  labelCompNumber.setText("****");
  partlyOpenedCompNumber = "****";

  numberInput.setValidator(new QIntValidator(this));

  table.setHorizontalHeaderLabels(QStringList({"Число", "Быки", "Коровы"}));
  table.horizontalHeader()->setSectionResizeMode(QHeaderView::Stretch);
  table.setEnabled(false);

  ai_table.setHorizontalHeaderLabels(QStringList({"Число", "Быки", "Коровы"}));
  ai_table.horizontalHeader()->setSectionResizeMode(QHeaderView::Stretch);
  ai_table.setEnabled(false);

  layout->addWidget(startButton, 0, 0);
  layout->addWidget(&statusMessage, 0, 1);
  layout->addWidget(&labelCompNumber, 0, 2);

  layout->addWidget(new QLabel("Введите число", this), 1, 0);
  layout->addWidget(&numberInput, 1, 1);
  layout->addWidget(&checkButton, 1, 2);
  layout->addWidget(&readNumButton, 1, 2);

  layout->addWidget(&table, 2, 0, 1, 3);
  layout->addWidget(new QLabel("Ходы компьютера", this), 4, 1);
  layout->addWidget(&ai_table, 5, 0, 1, 3);

  connect(startButton, SIGNAL(clicked()), SLOT(gameStart()));
  connect(&readNumButton, SIGNAL(clicked()), SLOT(readPersonNumber()));
  connect(&checkButton, SIGNAL(clicked()), SLOT(makeMove()));

  gameStop();

  srand(time(NULL));
}

void GameWidget::gameStart() {
    QMessageBox chosingDifficulty;
    QAbstractButton* lowDifficulty = chosingDifficulty.addButton(tr("Низкий"), QMessageBox::YesRole);
    chosingDifficulty.addButton(tr("Высокий"), QMessageBox::NoRole);
    chosingDifficulty.setText(tr("Выберите уровень сложности игры"));
    chosingDifficulty.setWindowTitle("Сложность игры");
    chosingDifficulty.exec();
    if (chosingDifficulty.clickedButton() == lowDifficulty) {
        isLowDifficult = 1;
    } else {
        isLowDifficult = 0;
    }

    statusMessage.setText("Загадайте число");
    numberInput.setEnabled(true);
    readNumButton.setEnabled(true);
    readNumButton.setVisible(true);
    checkButton.setEnabled(false);
    checkButton.setVisible(false);
    table.setEnabled(true);
    ai_table.setEnabled(true);
    labelCompNumber.setText("****");
    partlyOpenedCompNumber = "****";

    computerWon = false;
    personWon = false;
    for (int i = 0; i < compMarkedGuesses.size(); ++i) {
        compMarkedGuesses[i] = true;
    }

    numberInput.clear();
    while (table.rowCount() > 0) {
       table.removeRow(0);
    }
    while (ai_table.rowCount() > 0) {
       ai_table.removeRow(0);
    }
}

bool GameWidget::isValidNumber(int number, QString sNumber){
    if (number < 1000 || number > 9999) {
       return false;
    }

    for (int i = 0; i < sNumber.size(); i++) {
        for (int j = i + 1; j < sNumber.size(); ++j) {
            if(sNumber[i] == sNumber[j]){
                return false;
            }
        }
    }

    return true;
}

void GameWidget::readPersonNumber(){
    QString sValue = numberInput.text();
    int value = sValue.toInt();

    if(isValidNumber(value, sValue)){
        personNumber = sValue;
        computerNumber = getRandomNumberWithUniqueDigits();

        statusMessage.setText("Идет игра!");
        readNumButton.setEnabled(false);
        readNumButton.setVisible(false);
        checkButton.setVisible(true);
        checkButton.setEnabled(true);
    } else {
        statusMessage.setText("Некорректное число");
    }

    numberInput.clear();
}

bool GameWidget::isCharRepeated(QString sNumber, QChar charDigit){
    for (int i = 0; i < sNumber.size(); ++i) {
        if(charDigit == sNumber[i]){
            return true;
        }
    }

    return false;
}

QString GameWidget::getRandomNumberWithUniqueDigits() {
    int digit = 1 + rand() % 9;
    QString sValue = QString::number(digit);

    int sValueIndex = 1;
    while(sValueIndex < numberLength){
        digit = 0 + rand() % 10;
        QChar charDigit('0' + digit);

        if(!isCharRepeated(sValue, charDigit)){
            sValue += charDigit;
            sValueIndex++;
        }
    }

    return sValue;
}

void GameWidget::gameStop() {
    if(personWon){
        statusMessage.setText("Вы победили!");
    } else if(computerWon) {
        statusMessage.setText("Компьютер победил!");
    } else {
        statusMessage.setText("Игра не начата");
    }

    numberInput.setEnabled(false);
    readNumButton.setEnabled(false);
    checkButton.setEnabled(false);
    checkButton.setVisible(false);
    table.setEnabled(false);
    ai_table.setEnabled(false);
}

void GameWidget::makeMove() {
    statusMessage.setText("Идет игра");
    QString sValue = numberInput.text();
    int value = sValue.toInt();

    if(!isValidNumber(value, sValue)){
        statusMessage.setText("Некорректное число");
        return;
    }

    int nBulls = 0, nCows = 0;
    calcBullsAndCows(sValue, computerNumber, nCows, nBulls);

    table.insertRow(table.rowCount());
    table.setItem(table.rowCount()-1, 0, new QTableWidgetItem(sValue));
    table.setItem(table.rowCount()-1, 1, new QTableWidgetItem(QString::number(nBulls)));
    table.setItem(table.rowCount()-1, 2, new QTableWidgetItem(QString::number(nCows)));

    if(isLowDifficult){
        labelCompNumber.setText(partlyOpenedCompNumber);
    }

    if(sValue != computerNumber){
        computerMove();
    }
    else{
        personWon = true;
        gameStop();
    }
}

void GameWidget::initializeCompArray(){
    int compArrayIndex = 0;
    for (int firstDigit = 1; firstDigit <= 9; ++firstDigit) {
        for (int secondDigit = 0; secondDigit <= 9; ++secondDigit) {
            for (int thirdDigit = 0; thirdDigit <= 9; ++thirdDigit) {
                for (int fourthDigit = 0; fourthDigit <= 9; ++fourthDigit) {
                    compGuesses[compArrayIndex] = QString::number(firstDigit * 1000 + secondDigit * 100 + thirdDigit * 10 + fourthDigit);
                    compArrayIndex++;
                }
            }
        }
    }
}


bool GameWidget::isConvenientGuessArrayNumber(QString guessNumber, QString currentMoveNum, int nCows, int nBulls){
    int nBullsInGuessNum = 0;

    for (int i = 0; i < numberLength; ++i) {
        if(guessNumber[i] == currentMoveNum[i]){
            nBullsInGuessNum++;
        }
    }

    if(nBullsInGuessNum != nBulls){
        return false;
    }

    int nCowsInGuessNum = 0;
    for (int i = 0; i < numberLength; ++i) {
        if(guessNumber[i] != currentMoveNum[i] && isCharRepeated(guessNumber, currentMoveNum[i])){
            nCowsInGuessNum++;
        }
    }

    if(nCowsInGuessNum < nCows){
        return false;
    } else {
        return true;
    }
}

void GameWidget::computerMove(){
    QString sValue;

    if(compFirstMove){
        sValue = getRandomNumberWithUniqueDigits();
        compFirstMove = false;
    } else {
        while(true) {
            int i = 0 + rand() % compMarkedGuesses.size();
            if(compMarkedGuesses[i] && isValidNumber(compGuesses[i].toInt(), compGuesses[i])){
                sValue = compGuesses[i];
                break;
            } else {
                compMarkedGuesses[i] = false;
            }
        }
    }

    int nBulls = 0, nCows = 0;

    nBulls = QInputDialog::getText(this, tr("Число быков"), "Комьютер ввел число " + sValue + ". Число быков:",  QLineEdit::Normal).toInt();
    nCows = QInputDialog::getText(this, tr("Число коров"), "Комьютер ввел число " + sValue + ". Число коров:",  QLineEdit::Normal).toInt();

    ai_table.insertRow(ai_table.rowCount());
    ai_table.setItem(ai_table.rowCount()-1, 0, new QTableWidgetItem(sValue));
    ai_table.setItem(ai_table.rowCount()-1, 1, new QTableWidgetItem(QString::number(nBulls)));
    ai_table.setItem(ai_table.rowCount()-1, 2, new QTableWidgetItem(QString::number(nCows)));

    for (int i = 0; i < maxCompArraySize; ++i) {
        if(compMarkedGuesses[i] && !isConvenientGuessArrayNumber(compGuesses[i], sValue, nCows, nBulls)){
            compMarkedGuesses[i] = false;
        }
    }

    if(sValue == personNumber){
        computerWon = true;
        gameStop();
    }
}

void GameWidget::calcBullsAndCows(QString input, QString original, int& nCows, int& nBulls) { 
    for (int i = 0; i < input.size(); ++i) {
        if (input[i] == original[i]) {
          partlyOpenedCompNumber[i] = input[i];
          nBulls++;
          input[i] = ' ';
        }
     }

    for (int i = 0; i < input.size(); ++i) {
      if (input[i] == ' ')
        continue;

      for(int j = 0; j < original.size(); ++j){
          if(input[i] == original[j]){
              nCows++;
          }
      }
    }
}

