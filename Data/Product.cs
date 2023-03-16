using System;
using System.ComponentModel.DataAnnotations;

namespace BlazorDemo.Data
{
    /// <summary>
    /// 書籍テーブル・予約テーブル・お気に入りテーブル・予約履歴テーブル
    /// </summary>
    public class Product
    {
        public int Id { get; set; }
        public string? title { get; set; }
        public string? author { get; set; }
        [DataType(DataType.Date)]
        public DateTime updated_date { get; set; }
        public string? updated_by { get; set; }
        public string? tag { get; set; }
        public int quantity { get; set; }
        public string? imagePath { get; set; }
    }

    public class Reservations
    {
        public int Id { get; set; }
        public string? userID { get; set; }
        public int bookID { get; set; }
        public DateTime reservationDate { get; set; }
        public DateTime returnDate { get; set; }
    }

    public class Like
    {
        public int Id { get; set; }
        public string? userID { get; set; }
        public int bookID { get; set; }
    }

    public class ReservationHistory
    {
        public int Id { get; set; }
        public string? userID { get; set; }
        public int bookID { get; set; }
        public DateTime reservationDate { get; set; }
        public DateTime returnDate { get; set; }
        public string? title { get; set; }
        public string? author { get; set; }
        public DateTime updatedDate { get; set; }
        public string? updatedBy { get; set; }
    }

    public class ReservationTemporary
    {
        public int Id { get; set; }
        public string? userID { get; set; }
        public int bookID { get; set; }
        public DateTime reservationDate { get; set; }
    }
}

