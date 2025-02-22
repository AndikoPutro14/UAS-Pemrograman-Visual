Imports System
Imports System.IO

Public Class Program
    Public Shared Sub Main()
        Dim folderPath As String = "C:\Users\Andik\Desktop\Kuliahan\Semester 2\Pemrograman Visual\UAS"

        ' Memeriksa apakah folder ada
        If Directory.Exists(folderPath) Then
            Console.WriteLine("Folder ditemukan.")

            ' Meminta pengguna memasukkan kata kunci
            Console.Write("Masukkan kata kunci pencarian file: ")
            Dim keyword As String = Console.ReadLine()

            ' Mencari file menggunakan fungsi
            Dim files() As String = CariFile(folderPath, keyword)

            ' Memeriksa apakah ada file yang cocok
            If files.Length > 0 Then
                Console.WriteLine(vbCrLf & "Ditemukan " & files.Length & " file yang cocok:")

                For Each file As String In files
                    Console.WriteLine(vbCrLf & "Membaca file: " & Path.GetFileName(file))
                    BacaFile(file)
                Next
            Else
                Console.WriteLine("Tidak ada file yang cocok dengan kata kunci tersebut.")
            End If
        Else
            Console.WriteLine("Folder tidak ditemukan.") 
        End If

        Console.WriteLine(vbCrLf & "Masukan kata kunci pencarian file: ")

    End Sub

    ' Fungsi untuk mencari file berdasarkan kata kunci
    Public Shared Function CariFile(ByVal folderPath As String, ByVal keyword As String) As String()
        ' Menggunakan Directory.GetFiles untuk mencari file yang mengandung keyword dalam namanya
        Return Directory.GetFiles(folderPath, "*" & keyword & "*.txt")
    End Function

    ' Fungsi untuk membaca file
    Public Shared Sub BacaFile(ByVal path As String)
        Try
            ' Membaca file baris per baris
            Dim lines() As String = File.ReadAllLines(path)

            ' Menggunakan perulangan untuk menampilkan isi file
            For Each line As String In lines
                Console.WriteLine(line)
            Next
        Catch ex As Exception
            Console.WriteLine("Terjadi kesalahan: " & ex.Message)
        End Try
    End Sub
End Class