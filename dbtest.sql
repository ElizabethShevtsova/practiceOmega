CREATE TABLE users
(
    "userId" INTEGER PRIMARY KEY,
    login TEXT,
    password TEXT,
	FOREIGN KEY ("userId") REFERENCES datas (id)
);

CREATE TABLE datas
(
	id INTEGER PRIMARY KEY,
	surname TEXT,
	name TEXT,
	address TEXT,
	phone TEXT
);

INSERT INTO datas (id, surname, name, address, phone) VALUES (1, 'shevtsova', 'elizaveta', 'prospekt mira', 89512345678);
INSERT INTO datas (id, surname, name, address, phone) VALUES (2, 'chernishova', 'anna', 'prospekt voyni', 89587654321);

INSERT INTO users ("userId", login, password) VALUES (1, 'liza', '123');
INSERT INTO users ("userId", login, password) VALUES (2, 'anya', '777');
