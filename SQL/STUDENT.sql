DROP TABLE LOAN CASCADE CONSTRAINTS;
DROP TABLE CARTI CASCADE CONSTRAINTS;
DROP TABLE ACCOUNT CASCADE CONSTRAINTS;


CREATE TABLE CARTI (
  TITLU VARCHAR(255),
  AUTOR VARCHAR(255),
  CATEGORIE VARCHAR(255),
  STOC INT,
  TOTAL INT,
  ISBN VARCHAR(13),
  PRIMARY KEY (ISBN)
);

CREATE TABLE ACCOUNT (
  ID INT PRIMARY KEY,
  USERNAME VARCHAR(255) UNIQUE,
  PAROLA VARCHAR(255),
  NUME VARCHAR(255),
  PRENUME VARCHAR(255),
  CNP VARCHAR(13) UNIQUE,
  EMAIL VARCHAR(255) UNIQUE,
  ADRESA VARCHAR(255),
  ORAS VARCHAR(255),
  NUMAR_TELEFON VARCHAR(10) UNIQUE,
  TIP_CONT VARCHAR(11)
);

CREATE TABLE LOAN (
  ID INT PRIMARY KEY,
  ACCOUNT_ID INT,
  CARTI_ISBN VARCHAR(13),
  DATA_IMPRUMUT DATE,
  DATA_RESTITUIRE DATE,
  FOREIGN KEY (ACCOUNT_ID) REFERENCES ACCOUNT(ID),
  FOREIGN KEY (CARTI_ISBN) REFERENCES CARTI(ISBN)
);

INSERT INTO carti (titlu, autor, categorie, stoc, total, isbn)
VALUES
  ('The Great Gatsby', 'F. Scott Fitzgerald', 'Fiction', 2, 3, '9780142437419'),
  ('To Kill a Mockingbird', 'Harper Lee', 'Fiction', 2, 3, '9780446310789'),
  ('1984', 'George Orwell', 'Fiction', 2, 3, '9780451524935'),
  ('Pride and Prejudice', 'Jane Austen', 'Romance', 2, 3, '9780141439518'),
  ('The Catcher in the Rye', 'J.D. Salinger', 'Fiction', 2, 3, '9780316769174'),
  ('Amintiri din copilarie', 'Ion Creanga', 'Biography', 0, 3, '9780316769175'),
  ('Ion', 'Liviu Rebreanu', 'Fiction', 2, 3, '9780316769188'),
  ('Fluturi de noapte', 'Otilia Cazimir', 'Romance', 2, 3, '9780316769199'),
  ('Enigma Otiliei', 'George Calinescu', 'Mystery', 2, 3, '9780316769100');

INSERT INTO account (id, username, password, account_type)
VALUES
    (1, "matei.rares", "qweasdzxc", "User"),
    (2, "radu.dumitriu", "qweasdzxc", "Admin"),
    (3, "mihai.nejneriu", "qweasdzxc", "User"),
    (4, "ovi.catarama", "qweasdzxc", "User"),
    (5, "teodor.alexandru", "qweasdzxc", "Admin");

INSERT INTO loan (id, account_id, ISBN)
VALUES
    (1, 1, "9780142437419"),
    (2, 5, "9780451524935"),
    (3, 3, "9780316769175"),
    (4, 4, "9780316769175"),
    (5, 4, "9780316769100");


