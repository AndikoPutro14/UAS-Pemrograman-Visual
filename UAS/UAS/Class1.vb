Imports System
Imports System.IO

Public Class Program
    Public Shared Sub Main()
        Dim folderPath As String = "C:\Users\Andik\Desktop\Kuliahan\Semester 2\Pemrograman Visual\UAS"

        ' Periksa apakah folder ada
        If Not Directory.Exists(folderPath) Then
            Console.WriteLine("Folder tidak ditemukan.")
            Return
        End If

        Do
            Console.Write("Masukkan kata kunci pencarian file (atau ketik 'exit' untuk keluar): ")
            Dim keyword As String = Console.ReadLine()

            If keyword.ToLower() = "exit" Then
                Exit Do
            End If

            ' Cari file
            Dim files() As String = CariFile(folderPath, keyword)

            If files.Length = 0 Then
                Console.WriteLine("Tidak ada file yang cocok.")
                Continue Do
            End If

            Console.WriteLine(vbCrLf & "Ditemukan " & files.Length & " file yang cocok:")
            For Each file As String In files
                Console.WriteLine("- " & Path.GetFileName(file))
            Next

            ' Menampilkan isi file jika pengguna ingin membaca
            Console.Write("Ingin membaca file? (y/n): ")
            Dim pilihan As String = Console.ReadLine().ToLower()
            If pilihan = "y" Then
                For Each file As String In files
                    Console.WriteLine(vbCrLf & "Isi dari " & Path.GetFileName(file) & ":")
                    BacaFile(file)
                Next
            End If
        Loop
    End Sub

    ' Fungsi untuk mencari file berdasarkan kata kunci
    Public Shared Function CariFile(ByVal folderPath As String, ByVal keyword As String) As String()
        Return Directory.GetFiles(folderPath, "*" & keyword & "*.txt")
    End Function

    ' Fungsi untuk membaca file
    Public Shared Sub BacaFile(ByVal path As String)
        Try
            Dim lines() As String = File.ReadAllLines(path)
            For Each line As String In lines
                Console.WriteLine(line)
            Next
        Catch ex As Exception
            Console.WriteLine("Terjadi kesalahan: " & ex.Message)
        End Try
    End Sub
End Class
