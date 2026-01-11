# Sistem Manajemen Perpustakaan

Aplikasi desktop untuk mengelola perpustakaan menggunakan C# Windows Forms dan MySQL. Sistem ini mendukung peminjaman buku, pengelolaan buku dan pengguna dengan role-based access control.

## 📋 Fitur Utama

### Untuk Petugas (Staff)
- **Kelola Buku**: Tambah dan hapus data buku
- **Kelola Pengguna**: Tambah pengguna baru (anggota/petugas)
- **Peminjaman**: Meminjamkan buku kepada anggota dengan sistem due date otomatis (7 hari)
- **Pengembalian**: Memproses pengembalian buku yang dipinjam
- **Katalog**: Melihat dan mencari buku berdasarkan judul atau penulis

### Untuk Anggota (Member)
- **Katalog**: Melihat dan mencari koleksi buku perpustakaan

## 🛠️ Teknologi

- **Framework**: .NET 10.0 Windows Forms
- **Database**: MySQL
- **Package**: MySqlConnector 2.5.0
- **Bahasa**: C#

## 📁 Struktur Database

### Tabel Users
- `user_id` (INT, AUTO_INCREMENT, PRIMARY KEY)
- `username` (VARCHAR 100)
- `password` (VARCHAR 255)
- `role` (ENUM: 'anggota', 'petugas')
- `created_at`, `updated_at` (TIMESTAMP)

### Tabel Books
- `book_id` (INT, AUTO_INCREMENT, PRIMARY KEY)
- `title` (VARCHAR 100)
- `author` (VARCHAR 100)
- `status` (ENUM: 'tersedia', 'dipinjam')
- `created_at`, `updated_at` (TIMESTAMP)

### Tabel Loans
- `loan_id` (VARCHAR 10, PRIMARY KEY)
- `user_id` (INT, FOREIGN KEY → users)
- `book_id` (INT, FOREIGN KEY → books)
- `loan_date` (DATE)
- `due_date` (DATE)
- `returned_at` (DATETIME, NULL)

## 🚀 Instalasi

### Prasyarat
1. Visual Studio 2022 atau lebih baru
2. .NET 10.0 SDK
3. MySQL Server (XAMPP, WAMP, atau standalone)

### Langkah Instalasi

1. **Clone atau Download Project**
   ```bash
   git clone <repository-url>
   cd Perpustakaan
   ```

2. **Setup Database**
   - Jalankan MySQL server
   - Import file `perpustakaan.sql` ke MySQL:
     ```sql
     mysql -u root -p < perpustakaan.sql
     ```
   - Database akan otomatis dibuat dengan nama `perpustakaan` beserta sample data

3. **Konfigurasi Koneksi Database**
   - Buka file `db.cs`
   - Sesuaikan connection string jika diperlukan:
     ```csharp
     private const string CS = 
         "Server=localhost;Database=perpustakaan;User ID=root;Password=;SslMode=None;";
     ```

4. **Restore NuGet Packages**
   - Buka project di Visual Studio
   - Visual Studio akan otomatis restore package MySqlConnector
   - Atau jalankan manual:
     ```bash
     dotnet restore
     ```

5. **Build dan Run**
   - Tekan F5 di Visual Studio, atau
   - Build via command line:
     ```bash
     dotnet build
     dotnet run
     ```

## 👥 Default User

Setelah import database, tersedia 2 user default:

| Username  | Password | Role     |
|-----------|----------|----------|
| petugas1  | 123      | petugas  |
| ole       | abcd     | anggota  |

## 📚 Data Sample

Database sudah berisi 20 buku sample, termasuk:
- Laskar Pelangi (Andrea Hirata)
- Bumi (Tere Liye)
- Negeri 5 Menara (Ahmad Fuadi)
- Harry Potter dan Batu Bertuah (J.K. Rowling)
- The Hobbit (J.R.R. Tolkien)
- Dan lainnya...

## 🎯 Cara Penggunaan

### Login
1. Jalankan aplikasi
2. Masukkan username dan password
3. Klik tombol Login

### Meminjam Buku (Petugas)
1. Login sebagai petugas
2. Di halaman Katalog, pilih buku yang statusnya "tersedia"
3. Klik tombol "Pinjam"
4. Pilih anggota peminjam
5. Tentukan tanggal pinjam (default: hari ini)
6. Due date otomatis dihitung +7 hari
7. Klik "Simpan"

### Mengembalikan Buku (Petugas)
1. Klik tombol "Return" di Katalog
2. Pilih peminjaman yang aktif (belum dikembalikan)
3. Klik "Kembalikan"

### Mengelola Buku (Petugas)
1. Klik "Manage Books" di Katalog
2. **Tambah**: Klik "Tambah" → Isi judul & penulis → Simpan
3. **Hapus**: Pilih buku → Klik "Hapus" (tidak bisa hapus buku yang sedang dipinjam)

### Mengelola User (Petugas)
1. Klik "Manage User" di Katalog
2. **Tambah**: Klik "Tambah" → Isi username, password, pilih role → Simpan
3. **Hapus**: Pilih user → Klik "Hapus"

## 🔒 Validasi & Keamanan

- Buku yang sedang dipinjam tidak bisa dihapus
- Hanya petugas yang bisa mengakses fitur manajemen
- Status buku otomatis berubah saat dipinjam/dikembalikan
- Transaksi database menggunakan MySQL transaction untuk integritas data
- Foreign key constraints untuk mencegah data orphan

## 📝 Struktur File Project

```
Perpustakaan/
├── AddBook.cs / .Designer.cs / .resx       # Form tambah buku
├── AddUser.cs / .Designer.cs               # Form tambah user
├── Borrow.cs / .Designer.cs / .resx        # Form peminjaman
├── Catalog.cs / .Designer.cs / .resx       # Form katalog (halaman utama)
├── Login.cs / .Designer.cs                 # Form login
├── ManageBooks.cs / .Designer.cs / .resx   # Form kelola buku
├── ManageUsers.Designer.cs                 # Form kelola user
├── ReturnBooks.Designer.cs                 # Form pengembalian
├── books.cs                                # Model class Book
├── user.cs                                 # Model class User
├── db.cs                                   # Database connection helper
├── perpustakaan.sql                        # SQL schema & sample data
├── Perpustakaan.csproj                     # Project configuration
└── Properties/
    ├── Resources.Designer.cs
    └── Resources.resx
```

## 🐛 Troubleshooting

### Error: Unable to connect to any of the specified MySQL hosts
- Pastikan MySQL server sudah berjalan
- Cek konfigurasi connection string di `db.cs`

### Error: Table doesn't exist
- Import ulang file `perpustakaan.sql`
- Pastikan database `perpustakaan` sudah dibuat

### Error: MySqlConnector not found
- Restore NuGet packages:
  ```bash
  dotnet restore
  ```

## 📄 Lisensi

Project ini dibuat untuk keperluan edukasi dan pembelajaran.

## 👨‍💻 Kontributor

Dikembangkan sebagai sistem manajemen perpustakaan berbasis desktop dengan C# dan MySQL.

---

## 📄 Drive
https://drive.google.com/drive/folders/1d8nnE6KiwlO5VAK_nTKoXMHqoA2VaPU7?usp=drive_link
