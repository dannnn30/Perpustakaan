# User Testing (UAT) — Aplikasi Perpustakaan (WinForms + MySQL)

Dokumen ini berisi **User Acceptance Testing (UAT)** / skenario **user testing** untuk setiap program/form pada aplikasi **Perpustakaan**. Format test case dibuat dengan: **ID**, **Tujuan**, **Langkah**, dan **Expected Result**.

---

## Daftar Isi
- [Prasyarat](#prasyarat)
- [Test Data yang Disarankan](#test-data-yang-disarankan)
- [UAT per Program/Form](#uat-per-programform)
  - [1. Login](#1-login)
  - [2. Catalog](#2-catalog)
  - [3. Borrow](#3-borrow)
  - [4. ReturnBooks](#4-returnbooks)
  - [5. ManageBooks](#5-managebooks)
  - [6. AddBook](#6-addbook)
  - [7. ManageUsers](#7-manageusers)
  - [8. AddUser](#8-adduser)
- [Checklist End-to-End (Smoke Test)](#checklist-end-to-end-smoke-test)
- [Template Laporan Hasil UAT](#template-laporan-hasil-uat)

---

## Prasyarat
Sebelum testing, pastikan:
1. MySQL aktif dan aplikasi bisa konek ke database.
2. Database bernama `perpustakaan`.
3. Tabel minimal tersedia:
   - `users`
   - `books`
   - `loans`
4. Aturan data yang dipakai aplikasi:
   - `users.role`: `petugas` / `anggota`
   - `books.status`: `tersedia` / `dipinjam`
   - `loans.returned_at` = **NULL** artinya masih dipinjam (aktif)

---

## Test Data yang Disarankan
### Users
| username  | password | role   |
|----------|----------|---------|
| petugas1 | 123      | petugas |
| ole      | abcd     | anggota |

### Books
|     title      |     author     | status     |
|----------------|----------------|------------|
| Laskar Pelangi | Andrea Hirata  | tersedia   |
|      Bumi      |   Tere Liye    | dipinjam   |

> Catatan: Buku Bumi bisa dibuat status `dipinjam` lewat proses Borrow supaya realistis.

---

## UAT per Program/Form

### 1. Login

#### TC-LGN-01 — Login sukses (petugas)
**Tujuan:** memastikan login petugas sukses dan akses petugas aktif.  
**Langkah:**
1. Isi username: `petugas1`
2. Isi password: `123`
3. Klik **Login**  
**Expected Result:**
- Masuk ke **Catalog**
- Fitur petugas (Borrow/Manage/Return) terlihat/aktif

#### TC-LGN-02 — Login sukses (anggota)
**Tujuan:** memastikan login anggota sukses dan fitur petugas dibatasi.  
**Langkah:**
1. Username: `ole`
2. Password: `abcd`
3. Klik **Login**  
**Expected Result:**
- Masuk ke **Catalog**
- Tombol/fitur petugas tidak bisa dipakai (hidden/disabled)

#### TC-LGN-03 — Username/password kosong
**Tujuan:** validasi input login.  
**Langkah:**
1. Kosongkan username atau password
2. Klik **Login**  
**Expected Result:**
- Pesan error: “Isi username dan password.”
- Tetap di halaman Login

#### TC-LGN-04 — Salah password
**Tujuan:** memastikan sistem menolak kredensial salah.  
**Langkah:**
1. Username benar, password salah
2. Klik **Login**  
**Expected Result:**
- Pesan: “Login gagal. Cek username atau password.”
- Tidak masuk Catalog

#### TC-LGN-05 — DB mati / koneksi gagal
**Tujuan:** memastikan aplikasi tidak crash saat DB down.  
**Langkah:**
1. Matikan MySQL / putus koneksi
2. Coba login  
**Expected Result:**
- Muncul messagebox error (exception handling)
- Aplikasi tetap responsif (tidak force close)

---

### 2. Catalog

#### TC-CAT-01 — Load katalog awal
**Tujuan:** memastikan daftar buku tampil benar.  
**Langkah:**
1. Login
2. Lihat tabel buku  
**Expected Result:**
- Data buku tampil
- `book_id` tidak ditampilkan
- Tabel read-only (tidak bisa edit langsung), full-row select

#### TC-CAT-02 — Search judul/penulis (keyword valid)
**Tujuan:** memastikan fitur search bekerja.  
**Langkah:**
1. Isi search: `Laskar Pelangi` atau `Andrea Hirata`
2. Klik **Search**  
**Expected Result:**
- Data terfilter sesuai keyword (LIKE `%keyword%`)

#### TC-CAT-03 — Search kosong
**Tujuan:** memastikan search kosong menampilkan semua data.  
**Langkah:**
1. Kosongkan search
2. Klik **Search**  
**Expected Result:**
- Katalog kembali tampil semua

#### TC-CAT-04 — Petugas: Borrow hanya untuk buku tersedia
**Tujuan:** mencegah peminjaman buku yang sedang dipinjam.  
**Langkah:**
1. Login sebagai `petugas1`
2. Pilih buku status `dipinjam`
3. Klik **Borrow**  
**Expected Result:**
- Pesan: “Buku tidak tersedia (sedang dipinjam).”
- Form Borrow tidak terbuka

#### TC-CAT-05 — Petugas: Borrow tanpa pilih baris
**Tujuan:** validasi pemilihan buku.  
**Langkah:**
1. Login petugas
2. Jangan pilih baris buku
3. Klik **Borrow**  
**Expected Result:**
- Pesan: “Pilih buku dulu.”

#### TC-CAT-06 — Anggota mencoba menu petugas
**Tujuan:** memastikan role-based access.  
**Langkah:**
1. Login `ole`
2. Coba akses Manage Books/Manage Users/Return (jika ada tombolnya)  
**Expected Result:**
- Diblock (hidden/disabled) atau muncul pesan “Hanya petugas …”

#### TC-CAT-07 — Close Catalog balik ke Login
**Tujuan:** memastikan navigasi close benar.  
**Langkah:**
1. Klik Close di Catalog  
**Expected Result:**
- Catalog tertutup
- Form Login muncul kembali

---

### 3. Borrow

#### TC-BRW-01 — Borrow sukses (petugas → anggota)
**Tujuan:** memastikan loan tercatat dan status buku berubah.  
**Langkah:**
1. Dari Catalog (petugas), pilih buku status `tersedia`
2. Klik **Borrow**
3. Pilih anggota `ole`
4. Klik **Simpan**  
**Expected Result:**
- Pesan: “Peminjaman berhasil!”
- Form tertutup
- Buku status berubah jadi `dipinjam` di Catalog
- `loans` bertambah (returned_at = NULL)
- Due date otomatis = loan_date + 7 hari (ditampilkan)

#### TC-BRW-02 — Borrow tanpa pilih anggota
**Tujuan:** validasi pemilihan anggota.  
**Langkah:**
1. Buka Borrow
2. Tidak memilih anggota
3. Klik Simpan  
**Expected Result:**
- Pesan: “Pilih anggota.”
- Tidak ada perubahan di DB

#### TC-BRW-03 — Buku sudah dipinjam (race condition)
**Tujuan:** memastikan sistem menolak jika status buku sudah berubah sebelum simpan.  
**Langkah:**
1. Pastikan buku sudah `dipinjam`
2. Buka Borrow (mis. dari state UI yang belum refresh)
3. Klik Simpan  
**Expected Result:**
- Pesan: “Buku tidak tersedia / sudah dipinjam.”
- Tidak insert loan baru

#### TC-BRW-04 — Ubah tanggal pinjam → due date ikut berubah
**Tujuan:** memastikan due date reactive.  
**Langkah:**
1. Di Borrow, ubah `tanggal pinjam`
2. Perhatikan label due date  
**Expected Result:**
- Due date berubah otomatis (+7 hari dari tanggal pinjam)

#### TC-BRW-05 — Cancel
**Tujuan:** memastikan cancel tidak mengubah data.  
**Langkah:**
1. Klik **Cancel**  
**Expected Result:**
- Form tertutup
- Tidak ada perubahan DB

---

### 4. ReturnBooks

#### TC-RTN-01 — Return sukses
**Tujuan:** memastikan returned_at terisi dan status buku kembali tersedia.  
**Langkah:**
1. Login petugas
2. Buka ReturnBooks
3. Pilih 1 loan aktif
4. Klik **Kembalikan** → pilih **Yes**  
**Expected Result:**
- Pesan: “Berhasil dikembalikan!”
- `loans.returned_at` terisi (NOW())
- `books.status` jadi `tersedia`
- Tabel refresh (loan tersebut hilang dari daftar aktif)

#### TC-RTN-02 — Kembalikan tanpa pilih row
**Tujuan:** validasi pemilihan data.  
**Langkah:**
1. Buka ReturnBooks
2. Klik Kembalikan tanpa memilih data  
**Expected Result:**
- Pesan: “Pilih data peminjaman dulu.”

#### TC-RTN-03 — Loan sudah dikembalikan (idempotency)
**Tujuan:** mencegah pengembalian ganda.  
**Langkah:**
1. Coba return loan yang sama lagi (jika masih tampil)
2. Klik Kembalikan  
**Expected Result:**
- Pesan: “Gagal: data sudah dikembalikan / tidak ditemukan.”
- Tidak ada perubahan ganda

#### TC-RTN-04 — Cancel konfirmasi
**Tujuan:** memastikan opsi No tidak mengubah data.  
**Langkah:**
1. Klik Kembalikan
2. Pilih **No**  
**Expected Result:**
- Tidak ada perubahan DB
- Data tetap tampil

---

### 5. ManageBooks

#### TC-MBK-01 — Load daftar buku
**Tujuan:** memastikan list buku tampil.  
**Expected Result:**
- Daftar buku tampil: BookId, Title, Author, Status

#### TC-MBK-02 — Tambah buku (navigasi)
**Tujuan:** memastikan AddBook terhubung ke ManageBooks.  
**Langkah:**
1. Klik **Tambah**
2. Isi di AddBook → simpan  
**Expected Result:**
- Kembali ke ManageBooks
- Buku baru muncul (refresh)

#### TC-MBK-03 — Hapus buku status dipinjam
**Tujuan:** mencegah delete buku yang sedang dipinjam.  
**Langkah:**
1. Pilih buku status `dipinjam`
2. Klik **Hapus**  
**Expected Result:**
- Pesan: “Buku sedang dipinjam. Tidak bisa dihapus.”
- Buku tidak terhapus

#### TC-MBK-04 — Hapus buku yang punya loan aktif
**Tujuan:** mencegah delete buku dengan peminjaman aktif.  
**Langkah:**
1. Pilih buku yang punya `loans.returned_at = NULL`
2. Klik Hapus  
**Expected Result:**
- Pesan: “Buku masih punya peminjaman aktif. Tidak bisa dihapus.”
- Tidak terhapus

#### TC-MBK-05 — Hapus buku tersedia tanpa loan aktif
**Tujuan:** memastikan delete bekerja pada kondisi aman.  
**Langkah:**
1. Pilih buku `tersedia` dan tidak punya loan aktif
2. Klik Hapus → Yes  
**Expected Result:**
- Pesan: “Buku berhasil dihapus.”
- Buku hilang dari list

#### TC-MBK-06 — Hapus tanpa pilih row
**Tujuan:** validasi pemilihan data.  
**Langkah:**
1. Klik Hapus tanpa memilih data  
**Expected Result:**
- Pesan: “Pilih buku dulu.”

---

### 6. AddBook

#### TC-ABK-01 — Tambah buku sukses
**Tujuan:** insert buku baru dengan status default.  
**Langkah:**
1. Judul: `Tes Buku`
2. Penulis: `Tes Penulis`
3. Klik Tambah  
**Expected Result:**
- Pesan: “Buku berhasil ditambahkan. ID: …”
- Status tersimpan `tersedia`

#### TC-ABK-02 — Judul kosong
**Tujuan:** validasi judul wajib.  
**Langkah:**
1. Kosongkan Judul
2. Klik Tambah  
**Expected Result:**
- Pesan: “Judul wajib diisi.”
- Tidak ada insert DB

#### TC-ABK-03 — Penulis kosong (opsional)
**Tujuan:** memastikan penulis boleh kosong (jika memang diizinkan).  
**Langkah:**
1. Isi Judul
2. Kosongkan Penulis
3. Klik Tambah  
**Expected Result:**
- Buku tetap tersimpan (penulis null/empty)

#### Catatan (potensi bug)
- Tombol **Close** pada AddBook kemungkinan belum menutup form (handler kosong).
  - Buat test sederhana: klik Close → Expected: form tertutup. Actual: (cek di hasil UAT).

---

### 7. ManageUsers

#### TC-MUS-01 — Load daftar user
**Tujuan:** memastikan data user tampil.  
**Expected Result:**
- Daftar user tampil: user_id, username, password, role

#### TC-MUS-02 — Tambah user (navigasi)
**Tujuan:** memastikan AddUser terhubung ke ManageUsers.  
**Langkah:**
1. Klik Tambah
2. Isi di AddUser → simpan  
**Expected Result:**
- User baru muncul (refresh)

#### TC-MUS-03 — Hapus user yang masih punya loan aktif
**Tujuan:** mencegah delete user dengan peminjaman aktif.  
**Langkah:**
1. Pilih user yang punya loan aktif
2. Klik Hapus  
**Expected Result:**
- Pesan: “User masih punya peminjaman aktif. Tidak bisa dihapus.”

#### TC-MUS-04 — Hapus user tanpa pinjaman aktif
**Tujuan:** memastikan delete user bekerja.  
**Langkah:**
1. Pilih user tanpa loan aktif
2. Klik Hapus → Yes  
**Expected Result:**
- Pesan: “User berhasil dihapus.”
- Data user hilang dari list

#### TC-MUS-05 — Hapus tanpa pilih baris
**Tujuan:** validasi pemilihan data.  
**Expected Result:**
- Pesan: “Pilih user dulu di tabel.”

---

### 8. AddUser

#### TC-AUS-01 — Tambah anggota sukses
**Tujuan:** insert anggota baru.  
**Langkah:**
1. Username: `anggota_baru`
2. Password: `123`
3. Role: `anggota`
4. Klik Add  
**Expected Result:**
- Pesan: “User berhasil ditambahkan. ID: …”
- Data tersimpan di DB

#### TC-AUS-02 — Tambah petugas sukses
**Tujuan:** insert petugas baru.  
**Langkah:** sama seperti TC-AUS-01 tapi Role = `petugas`  
**Expected Result:** user tersimpan sebagai petugas

#### TC-AUS-03 — Field wajib kosong
**Tujuan:** validasi field wajib.  
**Langkah:**
1. Kosongkan username atau password atau role
2. Klik Add  
**Expected Result:**
- Pesan: “Username, Password, dan Role wajib diisi.”
- Tidak ada insert DB

#### TC-AUS-04 — Close
**Tujuan:** memastikan close membatalkan input.  
**Langkah:**
1. Klik Close  
**Expected Result:**
- Form tertutup
- Tidak ada insert DB

---

## Checklist End-to-End (Smoke Test)
Gunakan checklist ini untuk testing cepat:
1. Login petugas ✅  
2. Tambah buku baru ✅  
3. Borrow buku ke anggota ✅  
4. Pastikan status buku jadi `dipinjam` ✅  
5. Return buku ✅  
6. Pastikan status buku balik `tersedia` ✅  
7. Coba hapus buku yang masih dipinjam → ditolak ✅  
8. Login anggota → menu petugas diblok ✅  

---

## Template Laporan Hasil UAT
Salin template ini ke issue GitHub / dokumen laporan.

| Test Case ID | Module/Form | Steps Singkat | Expected Result | Actual Result | Status (PASS/FAIL) | Notes/Bug Link |
|-------------|-------------|---------------|-----------------|--------------|--------------------|----------------|
| TC-LGN-01   | Login       | ...           | ...             | ...          | PASS/FAIL          | ...            |

**Catatan tambahan:**
- Sertakan screenshot jika FAIL.
- Cantumkan data yang dipakai (username/book title) supaya bisa direplikasi.

---
