DROP TABLE WISHLIST CASCADE CONSTRAINTS;
DROP TABLE LOAN CASCADE CONSTRAINTS;
DROP TABLE CARTI CASCADE CONSTRAINTS;
DROP TABLE ACCOUNTS CASCADE CONSTRAINTS;

------------------------------------------------------------Functii GET----------------------------------------------------------------

DROP SEQUENCE GET_CARTI_ISBN;
DROP SEQUENCE GET_ACCOUNT_ID;
DROP SEQUENCE GET_LOAN_ID;
DROP SEQUENCE GET_WISHLIST_ID;

CREATE SEQUENCE GET_CARTI_ISBN
    START WITH 1 INCREMENT BY 1
    MINVALUE 1 
    MAXVALUE 9999;
    
CREATE SEQUENCE GET_ACCOUNT_ID
    START WITH 1 INCREMENT BY 1
    MINVALUE 1 
    MAXVALUE 9999;
    
CREATE SEQUENCE GET_LOAN_ID
    START WITH 1 INCREMENT BY 1
    MINVALUE 1 
    MAXVALUE 9999;
    
CREATE SEQUENCE GET_WISHLIST_ID
    START WITH 1 INCREMENT BY 1
    MINVALUE 1 
    MAXVALUE 9999;

------------------------------------------------------------------Creare Tabele----------------------------------------------------------------

CREATE TABLE CARTI (
  ISBN INT PRIMARY KEY,
  TITLU VARCHAR2(255),
  AUTOR VARCHAR2(255),
  CATEGORIE VARCHAR2(255),
  STOC INT,
  TOTAL INT
);

CREATE TABLE ACCOUNTS (
  ACCOUNT_ID INT PRIMARY KEY,
  USERNAME VARCHAR2(255) UNIQUE,
  PAROLA VARCHAR2(255),
  NUME VARCHAR2(255),
  PRENUME VARCHAR2(255),
  CNP VARCHAR2(13) UNIQUE,
  EMAIL VARCHAR2(255) UNIQUE,
  ADRESA VARCHAR2(255),
  ORAS VARCHAR2(255),
  NUMAR_TELEFON VARCHAR2(10) UNIQUE,
  TIP_CONT_ADMIN INT, --daca e admin=1, 0 daca nu e
  BLACK_LISTED INT --daca e pe lista neagra=1, 0 daca nu e
);

CREATE TABLE LOAN (
  LOAN_ID INT PRIMARY KEY,
  ACCOUNT_ID INT,
  CARTE_ISBN INT,
  DATA_IMPRUMUT DATE,
  DATA_RESTITUIRE DATE,
  ACCEPTED INT, --daca e 1=aprobat, 0=nu s a intamplat nimic 
  FOREIGN KEY (ACCOUNT_ID) REFERENCES ACCOUNTS(ACCOUNT_ID),
  FOREIGN KEY (CARTE_ISBN) REFERENCES CARTI(ISBN)
);

CREATE TABLE WISHLIST(
    WISHLIST_ID INT PRIMARY KEY,
    ACCOUNT_ID INT,
    CARTE_ISBN INT,
    FOREIGN KEY (ACCOUNT_ID) REFERENCES ACCOUNTS(ACCOUNT_ID),
    FOREIGN KEY (CARTE_ISBN) REFERENCES CARTI(ISBN)
);

--------------------------------------------------------------Exceptii-------------------------------------------------------------
 
CREATE OR REPLACE PACKAGE custom_exceptions AS
    email_duplicate_exception EXCEPTION;
    username_duplicate_exception EXCEPTION;
    stoc_insuficient_exception EXCEPTION;
    cnp_duplicate_exception EXCEPTION;
    nr_tel_duplicate_exception EXCEPTION;
END custom_exceptions;
/
-------------------------------------------------------------Functii Insert------------------------------------------------------------------------

CREATE OR REPLACE PROCEDURE insert_carte(p_titlu varchar2, p_autor varchar2, p_categorie varchar2, p_count int)
AS
    v_counter NUMBER;
    v_stoc INT;
    v_total INT;
    BEGIN
        SELECT COUNT(*) INTO v_counter FROM CARTI WHERE titlu = p_titlu AND autor = p_autor;
        IF v_counter = 0 THEN
            INSERT INTO CARTI VALUES(GET_CARTI_ISBN.nextval, p_titlu, p_autor, p_categorie, p_count, p_count);
        ELSE
            SELECT STOC, TOTAL INTO v_stoc, v_total FROM CARTI WHERE titlu = p_titlu AND autor = p_autor;
            v_stoc:=v_stoc+p_count;
            v_total:=v_total+p_count;
            UPDATE CARTI SET STOC=v_stoc, TOTAL=v_total WHERE titlu = p_titlu AND autor = p_autor;
        END IF;
        COMMIT;
    END;
    /
    
CREATE OR REPLACE PROCEDURE modificare_carte(p_isbn int, p_titlu varchar2, p_autor varchar2,p_categorie varchar2)
AS
    BEGIN
        UPDATE CARTI
        SET titlu = p_titlu,
            autor = p_autor,
            categorie = p_categorie
        WHERE isbn = p_isbn;
    END;
    /

 
 CREATE OR REPLACE PROCEDURE insert_account(p_username varchar2, p_parola varchar2, p_nume varchar2, p_prenume varchar2,
 p_cnp varchar2, p_email varchar2, p_adresa varchar2, p_oras varchar2, p_numar_telefon varchar2,
 p_tip_cont_admin int, p_black_listed int)
 AS
    v_counter NUMBER;
    BEGIN
    ------------------------Exceptie Username----------------------
        SELECT COUNT(*) INTO v_counter FROM ACCOUNTS WHERE username = p_username;
        IF v_counter = 1 THEN
            raise custom_exceptions.username_duplicate_exception;
        END IF;
    
    -----------------------------Exceptie Email---------------------------    
        SELECT COUNT(*) INTO v_counter FROM ACCOUNTS WHERE email = p_email;
        IF v_counter = 1 THEN
            raise custom_exceptions.email_duplicate_exception;
        END IF;
        
        ------------------------Exceptie CNP-------------------------------
        SELECT COUNT(*) INTO v_counter FROM ACCOUNTS WHERE CNP = p_cnp;
        IF v_counter = 1 THEN
            raise custom_exceptions.cnp_duplicate_exception;
        END IF;
        ------------------------Execptie Telefon---------------------------
        SELECT COUNT(*) INTO v_counter FROM ACCOUNTS WHERE numar_telefon = p_numar_telefon;
        IF v_counter = 1 THEN
            raise custom_exceptions.nr_tel_duplicate_exception;
        END IF;
        
        INSERT INTO ACCOUNTS VALUES(GET_ACCOUNT_ID.nextval, p_username, p_parola, p_nume, p_prenume, 
        p_cnp, p_email, p_adresa, p_oras, p_numar_telefon, p_tip_cont_admin, p_black_listed);
        COMMIT;
        
        EXCEPTION
    WHEN custom_exceptions.email_duplicate_exception THEN
        raise_application_error(-20001, 'Email deja existent!' || p_email);
    WHEN custom_exceptions.username_duplicate_exception THEN
        raise_application_error(-20002, 'Username deja existent!' || p_username);
    WHEN custom_exceptions.cnp_duplicate_exception THEN
        raise_application_error(-20003, 'CNP deja existent!' || p_cnp);
    WHEN custom_exceptions.nr_tel_duplicate_exception THEN
        raise_application_error(-20004, 'Numar de telefon deja existent!' || p_numar_telefon); 
    WHEN OTHERS THEN
        raise_application_error(-20100, 'S-a produs o exceptie la inserarea unui cont!');
        
    END;
    /
 
 CREATE OR REPLACE PROCEDURE insert_loan(p_account_id varchar2, p_carte_isbn varchar2)
 AS
    BEGIN
        INSERT INTO LOAN VALUES(GET_LOAN_ID.nextval, p_account_id, p_carte_isbn, SYSDATE, SYSDATE, 0);
        COMMIT;
    END;
    /
    
CREATE OR REPLACE PROCEDURE delete_loan(p_loan_id int)
 AS
    BEGIN
        DELETE FROM LOAN WHERE loan_id = p_loan_id;
        COMMIT;
    END;
    /  
    
 CREATE OR REPLACE PROCEDURE accept_loan(p_loan_id int)
 AS
    v_carte_isbn NUMBER;
    v_stoc NUMBER;
    v_accepted NUMBER;
    BEGIN
    v_accepted := 0;
    SELECT carte_isbn INTO v_carte_isbn FROM LOAN WHERE loan_id = p_loan_id;
    SELECT stoc INTO v_stoc FROM CARTI WHERE isbn = v_carte_isbn;  
    
    IF v_stoc >= 1 THEN
        UPDATE loan SET accepted=1, data_imprumut=SYSDATE, data_restituire=SYSDATE+14 WHERE loan_id = p_loan_id;
        UPDATE carti SET stoc=v_stoc-1 WHERE isbn = v_carte_isbn;
        v_stoc := v_stoc-1;
        v_accepted := 1;
    END IF;
    
    IF v_stoc = 0 THEN
        DELETE FROM loan WHERE carte_isbn = v_carte_isbn AND accepted = 0;
        IF v_accepted = 0 THEN
            raise custom_exceptions.stoc_insuficient_exception;
        END IF;
    END IF;
        COMMIT;
        
        EXCEPTION
    WHEN  custom_exceptions.stoc_insuficient_exception THEN
        raise_application_error(-20050, 'Stoc insuficient!' || v_stoc);
    WHEN OTHERS THEN
        raise_application_error(-20101, 'S-a produs o eroare la ACCEPT_LOAN');
        
    END;
    /     
    
 CREATE OR REPLACE PROCEDURE insert_wishlist(p_account_id int, p_carte_isbn int)
 AS
    BEGIN
        INSERT INTO WISHLIST VALUES(GET_WISHLIST_ID.nextval, p_account_id, p_carte_isbn);
        COMMIT;
    END;
    /   
    
CREATE OR REPLACE PROCEDURE delete_wishlist(p_id int)
 AS
    BEGIN
        DELETE FROM WISHLIST WHERE wishlist_id=p_id;
        COMMIT;
    END;
    /
    
CREATE OR REPLACE PROCEDURE add_black_listed(p_account_id int)
 AS
    BEGIN
        UPDATE accounts SET black_listed=1 WHERE account_id=p_account_id;
        COMMIT;
    END;
    /   
    
CREATE OR REPLACE PROCEDURE delete_black_listed(p_account_id int)
 AS
    BEGIN
        UPDATE accounts SET black_listed=0 WHERE account_id=p_account_id;
        COMMIT;
    END;
    /   
    
CREATE OR REPLACE PROCEDURE delete_book(p_isbn int)
 AS
    BEGIN
        DELETE FROM WISHLIST WHERE carte_isbn = p_isbn;
        DELETE FROM LOAN WHERE carte_isbn = p_isbn;
        DELETE FROM CARTI WHERE isbn = p_isbn;
        COMMIT;
    END;
    / 
  
 --------------------------------------------------------Inserari in tabele----------------------------------------------------------------------
 
 BEGIN 
    insert_carte('The Great Gatsby', 'F. Scott Fitzgerald', 'Fiction', 3);
    insert_carte('Amintiri din copilarie', 'Ion Creanga', 'Roman', 2);
    insert_carte('Din cer au cazut 3 mere', 'Narine Abgarian', 'Literatura Universala', 4);
    insert_carte('Inocentii', 'Ioana Parvulescu', 'Roman', 1);
    insert_carte('Totul incepe cu noi', 'Colleen Hoover', 'Roman de dragoste', 2);
 END;
 /
 
 BEGIN
    modificare_carte(3,'Din cer au cazut 4 mere', 'Narin Abgarian', 'Drama');
 END;
 /
 
    BEGIN 
    insert_account('radumitriu', 'suntsmecher', 'Dumitriu', 'Radu', '5010303270824', 'radumitritiu@yahoo.com',
    'Jud Neamt', 'Roman', '0744897953', 1, 0);
    END;
    /
    
    BEGIN
        insert_account('mihainejne', 'estismecher', 'Nejneriu', 'Mihai', '5010303270825', 'mihainejne@gmail.com',
    'Jud Bacau', 'Bacau', '0744897954', 0, 0);
    END;
    /
    
    BEGIN
        insert_account('admin', 'admin', 'Dumitri', 'Marcel', '5010303270823', 'radumitritiu77@yahoo.com',
    'Jud Neamt', 'Roman', '0743897954', 1, 0);
    END;
    /
    
    BEGIN
        insert_account('user', 'user', 'Lolo', 'Mircea', '5010303270821', 'mihainejneeee@gmail.com',
    'Jud Bacau', 'Bacau', '0741893954', 0, 0);
     END;
     /
 
 BEGIN 
    insert_loan(1,1);
    insert_loan(2,2);
 END;
 /
 
 BEGIN 
    insert_wishlist(1,1);
    insert_wishlist(2,1);
 END;
 /








