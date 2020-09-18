int Ans1() 
{
	string nameG, nameCE, temp;
	cout << "Введите название разработчика: ";
	getline(cin, nameG);
	cout << "\nВведите название коллекции: ";
	getline(cin, nameCE);
	ifstream al("Data\\Collections.txt");

	int find = 0;
	while (!al.eof()) {
		getline(al, temp);
		if (temp.find(nameG) != -1 && temp.find(nameCE) != -1) {
			find = 1;
			break;
		}
	}
	al.close();
	if (!find) {
		cout << "Коллекция не найдена!";
		return 0;
	}
	find = 0;
	al.open("Data\\Games.txt");
	while (!al.eof()) {
		getline(al, temp);
		if (temp.find(nameCE) != -1)
			break;
	}
	al.close();
	temp.erase(temp.find(nameCE), nameCE.length());
	for (int i = 0; i < temp.length(); i++) {
		if (temp[i] == ':') {
			temp.erase(i - 1, 3);
			i -= 1;
		}
		else if (temp[i] == ';') {
			temp.erase(i, 1);
			i -= 1;
		}
		else if (temp[i] == ',') {
			temp.erase(i - 1, 3);
			i -= 1;
			temp.insert(i, "\n");
		}
	}
	cout << endl << "Названия игр коллекции " << nameCE << " разработчика " << nameG << ":" << endl << temp;
}

int Ans2() 
{
	string izdat, temp;
	cout << "Введите название издателя: ";
	getline(cin, izdat);
	ifstream lab("Data\\Publishers.txt");
	int find = 0;
	while (!lab.eof()) {
		getline(lab, temp);
		if (temp.find(izdat) != -1) {
			find = 1;
			break;
		}
	}
	lab.close();
	if (!find) {
		cout << "Издатель не найден!";
		return 0;
	}
	cout << "\nКоличество разработчиков издателя " << izdat << ": ";
	int i = temp.find("("), j = temp.find(")");
	if (j != i + 2) {
		cout << temp[i + 1] << temp[i + 2];
	}
	else
		cout << temp[i + 1];
}

int Ans3() {
	string developer, temp, result = "";
	cout << "Введите имя разработчика: ";
	getline(cin, developer);
	ifstream f("Data\\Players.txt");
	int find = 0;
	while (!f.eof()) {
		getline(f, temp);
		if (temp.find(developer) != -1) {
			for (int i = 0; i < temp.find(":") - 1; i++)
				result += temp[i];
			result += "\n";
			find = 1;
		}
	}
	if (!find) {
		cout << "Разработчик не найден!";
		return 0;
	}
	cout << "\nСписок игроков разработчика " << developer << ":\n" << result;
}

int Ans4() 
{
	string dev1, dev2, temp1, temp2, temp, collection;
	cout << "Введите имя первого разработчика: ";
	getline(cin, dev1);
	cout << "Введите имя второго разработчика: ";
	getline(cin, dev2);
	ifstream f("Data\\Collections.txt");
	int find1 = 0, find2 = 0;
	while (!f.eof()) {
		getline(f, temp);
		if (temp.find(dev1) != -1) {
			temp1 = temp;
			find1 = 1;
		}
		if (temp.find(dev2) != -1) {
			temp2 = temp;
			find2 = 1;
		}
	}
	f.close();
	if (!find1 || !find2) {
		cout << "Разработчик не найден!";
		return 0;
	}
	int i = temp1.find(":") + 2, find = 0;
	for (i; i < temp1.length(); i++) {
		collection += temp1[i];
		if (temp1[i + 2] == '(') {
			if (temp2.find(collection) != -1) {
				find = 1;
				break;
			}
			else {
				i += 10;
				collection = "";
			}
		}
	}
	if (!find) {
		cout << "У разработчиков нет общих игр!";
		return 0;
	}
	f.open("Data\\Games.txt");
	while (!f.eof()) {
		getline(f, temp);
		if (temp.find(collection) != -1)
			break;
	}
	f.close();
	temp.erase(temp.find(collection), collection.length());
	for (int i = 0; i < temp.length(); i++) {
		if (temp[i] == ':') {
			temp.erase(i - 1, 3);
			i -= 1;
		}
		else if (temp[i] == ';') {
			temp.erase(i, 1);
			i -= 1;
		}
		else if (temp[i] == ',') {
			temp.erase(i - 1, 3);
			i -= 1;
			temp.insert(i, "\n");
		}
	}
	cout << endl << "Названия общих игр " << dev1 << " и " << dev2 << ":" << endl << temp;
}

int Ans5() 
{
	string user, temp;
	cout << "Введите никнейм игрока: ";
	getline(cin, user);
	ifstream f("Data\\Categories.txt");
	int find = 0;
	while (!f.eof()) {
		getline(f, temp);
		if (temp.find(user) != -1) {
			find = 1;
			break;
		}
	}
	f.close();
	if (!find) {
		cout << "Пользователь не найден!";
		return 0;
	}
	temp.erase(temp.find(user), user.length());
	for (int i = 0; i < temp.length(); i++) {
		if (temp[i] == ':') {
			temp.erase(i - 1, 3);
			i -= 1;
		}
		else if (temp[i] == ';') {
			temp.erase(i, 1);
			i -= 1;
		}
		else if (temp[i] == ',') {
			temp.erase(i - 1, 3);
			i -= 1;
			temp.insert(i, "\n");
		}
	}
	cout << endl << "Названия категорий игрока " << user << ":\n" << temp;
}

int Ans6() {
	string dev, temp;
	cout << "Введите имя разработчика: ";
	getline(cin, dev);
	ifstream f("Data\\Developers.txt");
	int find = 0;
	while (!f.eof()) {
		getline(f, temp);
		if (temp.find(dev) != -1) {
			find = 1;
			break;
		}
	}
	f.close();
	if (!find) {
		cout << "Разработчик не найден!";
		return 0;
	}
	string result = "";
	int i = temp.rfind(dev) + dev.length() + 2;
	for (i; temp[i] != ')'; i++)
		result += temp[i];
	cout << "\nКоличество игр разработчика " << dev << ": " << result;
}
int Ans7() {
	string Collection, temp;
	cout << "Введите название коллекции: ";
	getline(cin, Collection);
	ifstream f("Data\\Collections.txt");
	int find = 0;
	while (!f.eof()) {
		getline(f, temp);
		if (temp.find(Collection) != -1) {
			find = 1;
			break;
		}
	}
	f.close();
	if (!find) {
		cout << "Коллекция не найдена!";
		return 0;
	}
	string result = "";
	int i = temp.rfind(Collection) + Collection.length() + 2;
	for (i; temp[i] != ')'; i++)
		result += temp[i];
	cout << "\nГод создания коллекции " << Collection << ": " << result;
}
int Ans8() {
	string user1, user2, temp1, temp2, temp;
	cout << "Введите имя первого игрока: ";
	getline(cin, user1);
	cout << "Введите имя второго игрока: ";
	getline(cin, user2);
	ifstream f("Data\\Gamers.txt");
	int find1 = 0, find2 = 0;
	while (!f.eof()) {
		getline(f, temp);
		if (temp.find(user1) != -1) {
			temp1 = temp;
			find1 = 1;
		}
		if (temp.find(user2) != -1) {
			temp2 = temp;
			find2 = 1;
		}
	}
	f.close();
	if (!find1 || !find2) {
		cout << "Разработчик не найден!";
		return 0;
	}
	string singer = "", result = "";
	int i = temp1.find(":") + 2, find = 0;
	for (i; i < temp1.length() - 1; i++) {
		singer += temp1[i];
		if (temp1[i + 2] == ',' || temp1[i + 2] == ';') {
			if (temp2.find(singer) != -1) {
				find = 1;
				result += singer + "\n";
				singer = "";
				i += 3;
			}
			else {
				i += 3;
				singer = "";
			}
		}
	}
	if (!find) {
		cout << "У разработчиков нет общих игр!";
		return 0;
	}
	cout << "\nОбщие интересующие разработчики " << user1 << " и " << user2 << ":\n" << result;
}
int Ans9() {
	string dev, temp;
	cout << "Введите имя разработчика: ";
	getline(cin, dev);
	ifstream f("Data\\Collections.txt");
	int find = 0;
	while (!f.eof()) {
		getline(f, temp);
		if (temp.find(dev) != -1) {
			find = 1;
			break;
		}
	}
	f.close();
	if (!find) {
		cout << "\nРазработчик не найден!";
		return 0;
	}
	string album = "";
	vector<string> albums;
	int i = dev.length() + 4;
	for (i; i < temp.length() - 1; i++) {
		album += temp[i];
		if (temp[i + 2] == '(') {
			albums.push_back(album);
			album = "";
			i += 11;
		}
	}
	string result = "";
	f.open("Data\\Games.txt");
	while (!f.eof()) {
		getline(f, temp);
		for (i = 0; i < albums.size(); i++) {
			if (temp.find(albums[i]) != -1) {
				for (int j = temp.find(albums[i]) + albums[i].length() + 3; j < temp.length() - 1; j++) {
					result += temp[j];
					if (temp[j + 2] == ',' || temp[j + 2] == ';') {
						result += "\n";
						j += 3;
					}
				}
			}
		}
	}
	cout << "\nВсе игры разработчика " << dev << ":\n" << result;
}

int Ans10() 
{
	string play, user, temp;
	cout << "Введите имя игрока: ";
	getline(cin, user);
	cout << "\nВведите название категории: ";
	getline(cin, play);
	ifstream f("Data\\Categories.txt");
	int find = 0;
	while (!f.eof()) {
		getline(f, temp);
		if (temp.find(user) != -1 && temp.find(play) != -1) {
			find = 1;
			break;
		}
	}
	f.close();
	if (!find) {
		cout << "Категория не найдена!";
		return 0;
	}
	find = 0;
	f.open("Data\\Playlists_Songs.txt");
	while (!f.eof()) {
		getline(f, temp);
		if (temp.find(play) != -1)
			break;
	}
	f.close();
	temp.erase(temp.find(play), play.length());
	for (int i = 0; i < temp.length(); i++) {
		if (temp[i] == ':') {
			temp.erase(i - 1, 3);
			i -= 1;
		}
		else if (temp[i] == ';') {
			temp.erase(i, 1);
			i -= 1;
		}
		else if (temp[i] == ',') {
			temp.erase(i - 1, 3);
			i -= 1;
			temp.insert(i, "\n");
		}
	}
	cout << endl << "Названия игр категории " << play << " игрока " << user << ":" << endl << temp;
}
