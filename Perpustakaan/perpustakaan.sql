CREATE DATABASE IF NOT EXISTS perpustakaan;
USE perpustakaan;

DROP TABLE loans;
DROP TABLE users;
DROP TABLE books;

CREATE TABLE users (
    user_id INT AUTO_INCREMENT PRIMARY KEY,
    username VARCHAR(100) NOT NULL,
    password VARCHAR(255) NOT NULL,
    role ENUM('anggota', 'petugas') NOT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
);
ALTER TABLE users ENGINE=InnoDB;

CREATE TABLE books (
  book_id    INT AUTO_INCREMENT PRIMARY KEY,
  title      VARCHAR(100) NOT NULL,
  author     VARCHAR(100),
  status     ENUM('tersedia', 'dipinjam') NOT NULL DEFAULT 'tersedia',
  created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
  updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
);
ALTER TABLE books ENGINE=InnoDB;

CREATE TABLE loans (
  loan_id     VARCHAR(10) PRIMARY KEY,
  user_id     INT NOT NULL,
  book_id     INT NOT NULL,
  loan_date   DATE NOT NULL,
  due_date    DATE NOT NULL,
  returned_at DATETIME NULL,

  CONSTRAINT fk_loans_users FOREIGN KEY (user_id) REFERENCES users(user_id),
  CONSTRAINT fk_loans_books FOREIGN KEY (book_id) REFERENCES books(book_id),

  INDEX idx_loans_user (user_id),
  INDEX idx_loans_book (book_id),
  INDEX idx_loans_active (returned_at)
);
ALTER TABLE loans ENGINE=InnoDB;


INSERT INTO users (user_id, username, password, role) VALUES
(1,'petugas1','123','petugas'),
(2, 'ole', 'abcd', 'anggota');
 
INSERT INTO books (book_id, title, author, status) VALUES
(001,'Laskar Pelangi','Andrea Hirata','tersedia'),
(002,'Bumi','Tere Liye','tersedia'),
(003,'Negeri 5 Menara','Ahmad Fuadi','tersedia'),
(004,'Hujan','Tere Liye','tersedia'),
(005,'Dilan 1990','Pidi Baiq','tersedia'),
(006,'Ayat-Ayat Cinta','Habiburrahman El Shirazy','tersedia'),
(007,'Ronggeng Dukuh Paruk','Ahmad Tohari','tersedia'),
(008,'Sang Pemimpi','Andrea Hirata','tersedia'),
(009,'Pulang','Tere Liye','tersedia'),
(010,'Perahu Kertas','Dewi Lestari','tersedia'),
(011,'Supernova','Dewi Lestari','tersedia'),
(012,'Filosofi Teras','Henry Manampiring','tersedia'),
(013,'Atomic Habits','James Clear','tersedia'),
(014,'Rich Dad Poor Dad','Robert T. Kiyosaki','tersedia'),
(015,'The Psychology of Money','Morgan Housel','tersedia'),
(016,'Clean Code','Robert C. Martin','tersedia'),
(017,'The Pragmatic Programmer','Andrew Hunt','tersedia'),
(018,'Harry Potter dan Batu Bertuah','J.K. Rowling','tersedia'),
(019,'Harry Potter dan Kamar Rahasia','J.K. Rowling','tersedia'),
(020,'The Hobbit','J.R.R. Tolkien','tersedia');