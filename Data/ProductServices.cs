using System;
using Microsoft.EntityFrameworkCore;

namespace BlazorDemo.Data
{
    public class ProductServices
    {
        /// <summary>
        /// Productデータベース
        /// 本テーブル（Product）・予約テーブル（Reserve）・お気に入りテーブル（Like）
        /// 各テーブルのCRUD系のメソッドを記載
        /// </summary>
        #region Private members
        private ProductDbContext dbContext;
        #endregion

        #region Constructor
        public ProductServices(ProductDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        #endregion

        #region Public methods
        /// <summary>
        /// メソッド一覧
        /// Get系
        /// GetProductAsync・GetReservationsAsync・GetLikeAsync・GetProductByTitleAsync・GetProductByAuthorAsync・GetProductByTagAsync・GetProductByIDAsync
        /// GetProductQuantityAsync・GetRecordCountAsync・GetBookTitlesAndReturnDatesByUserAsync・GetLikesByUserAsync
        /// Add系
        /// AddProductAsync・AddReservationsAsync・AddLikeAsyncUpdateProductAsync
        /// Delete系
        /// DeleteProductAsync・DeleteReservationsAsync
        /// </summary>
        /// <returns></returns>

        /// 本の全レコードを取得 ///
        public async Task<List<Product>> GetProductAsync()
        {
            return await dbContext.Product.ToListAsync();
        }
        /// 予約の全レコードを取得 ///
        public async Task<List<Reservations>> GetReservationsAsync()
        {
            return await dbContext.Reservations.ToListAsync();
        }
        /// 仮予約の全レコードを取得 ///
        public async Task<List<ReservationTemporary>> GetTemoraryReservationsAsync()
        {
            return await dbContext.ReservationTemporary.ToListAsync();
        }
        /// お気に入りの全レコードを取得 ///
        public async Task<List<Like>> GetLikeAsync()
        {
            return await dbContext.Like.ToListAsync();
        }
        /// 本のタイトルを引数に一致するレコードを取得 ///
        public async Task<List<Product>> GetProductByTitleAsync(string title)
        {
            return await dbContext.Product.Where(p => EF.Functions.Like(p.title, $"%{title}%")).ToListAsync();
        }
        /// 本の全著者を引数に一致するレコードを取得 ///
        public async Task<List<Product>> GetProductByAuthorAsync(string title)
        {
            return await dbContext.Product.Where(p => EF.Functions.Like(p.author, $"%{title}%")).ToListAsync();
        }
        /// 本のタグを引数に一致するレコードを取得 ///
        public async Task<List<Product>> GetProductByTagAsync(string title)
        {
            return await dbContext.Product.Where(p => EF.Functions.Like(p.tag, $"%{title}%")).ToListAsync();
        }
        /// 本のIDを引数に一致するレコードを取得 ///
        public async Task<List<Product>> GetProductByIDAsync(int id)
        {
            return await dbContext.Product.Where(p => p.Id == id).ToListAsync();
        }
        /// 本のタイトルを引数に一致するレコードの数量のカラムを取得 ///
        public async Task<int> GetProductQuantityAsync(string title)
        {
            return await dbContext.Product
                    .Where(p => EF.Functions.Like(p.title, $"%{title}%"))
                    .Select(p => p.quantity)
                    .FirstOrDefaultAsync();
        }
        /// 本のタイトルを引数に一致するレコードの数量のカラムを取得。そのカラムの数を戻り値にする ///
        public async Task<int> GetRecordCountAsync(int id)
        {
            return await dbContext.Reservations.Where(r => r.bookID == id).CountAsync();
        }
        /// ユーザIDを引数に一致するレコードを予約テーブルから取得、そのレコードに含まれているbookIDを引数に本テーブルのbookIDを取得、 ///
        /// 本情報と予約情報を結合して本タイトルと返却日のタプルのリストを取得
        public async Task<List<(string? title, DateTime returnDate)>> GetBookTitlesAndReturnDatesByUserAsync(string userId)
        {
            var reservations = await dbContext.Reservations
                    .Where(r => r.userID == userId)
                    .ToListAsync();

            var books = await dbContext.Product
                    .Where(p => reservations.Select(r => r.bookID).Contains(p.Id))
                    .ToListAsync();

            return books.Join(reservations,
                    b => b.Id,
                    r => r.bookID,
                    (b, r) => (b.title, r.returnDate))
                    .ToList();
        }
        /// ユーザーIDを引数に一致するレコードをLikeテーブルから取得し、そのレコードbookIDと一致するレコードをProductテーブルから取得、そのレコードのタイトルだけを取得 ///
        public async Task<List<string?>> GetLikesByUserAsync(string userId)
        {
            var likes = await dbContext.Like
                    .Where(l => l.userID == userId)
                    .ToListAsync();

            var books = await dbContext.Product
                    .Where(p => likes.Select(l => l.bookID).Contains(p.Id))
                    .ToListAsync();

            return books.Select(b => b.title).ToList();
        }
        /// ユーザーIDを引数に一致するレコードをReserveTemporaryテーブルから取得し、そのレコードbookIDと一致するレコードをProductテーブルから取得、そのレコードのタイトルだけを取得 ///
        public async Task<List<string?>> GetTemporaryReserveByUserAsync(string userId)
        {
            var likes = await dbContext.ReservationTemporary
                    .Where(l => l.userID == userId)
                    .ToListAsync();

            var books = await dbContext.Product
                    .Where(p => likes.Select(l => l.bookID).Contains(p.Id))
                    .ToListAsync();

            return books.Select(b => b.title).ToList();
        }
        /// 本テーブルに新しいレコードを追加 ///
        public async Task<Product> AddProductAsync(Product product)
        {
            try
            {
                dbContext.Product.Add(product);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
            return product;
        }
        /// 予約テーブルに新しいレコードを追加 ///
        public async Task<Reservations> AddReservationsAsync(Reservations Reservations)
        {
            try
            {
                dbContext.Reservations.Add(Reservations);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
            return Reservations;
        }
        /// 仮予約テーブルに新しいレコードを追加 ///
        public async Task<ReservationTemporary> AddTemporaryReservationsAsync(ReservationTemporary reservationTemporary)
        {
            try
            {
                dbContext.ReservationTemporary.Add(reservationTemporary);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
            return reservationTemporary;
        }
        /// 予約テーブルに新しいレコードを追加 ///
        public async Task<Like> AddLikeAsync(Like like)
        {
            try
            {
                dbContext.Like.Add(like);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
            return like;
        }
        /// 予約履歴テーブルに新しいレコードを追加 ///
        public async Task<ReservationHistory> AddReservationHistoryAsync(ReservationHistory reservationHistory)
        {
            try
            {
                dbContext.ReservationHistory.Add(reservationHistory);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
            return reservationHistory;
        }
        /// productオブジェクトを引数に受け取り、データベース内の一致するカラムを更新 ///
        public async Task<Product> UpdateProductAsync(Product product)
        {
            try
            {
                var productExist = dbContext.Product.FirstOrDefault(p => p.Id == product.Id);
                if (productExist != null)
                {
                    dbContext.Update(product);
                    await dbContext.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return product;
        }
        /// productオブジェクトを引数に受け取り、データベース内の一致するカラムを削除 ///
        public async Task DeleteProductAsync(Product product)
        {
            try
            {
                dbContext.Product.Remove(product);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// Reservationオブジェクトを引数に受け取り、データベース内の一致するカラムを削除 ///
        public async Task DeleteReservationsAsync(Reservations Reservation)
        {
            try
            {
                dbContext.Reservations.Remove(Reservation);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// 本のtitleとuserIDを引数に受け取り、まずProductテーブルから該当するtitleと一致するレコードを一つ取得 <summary>
        /// 次にそのレコードのbookIDを取得、後はuserIDとアンパサンドされている値だけを一つ取得する。そのレコードを削除
        public async Task DeleteLikeAsync(string title, string userID)
        {
            try
            {
                var product = dbContext.Product.FirstOrDefault(p => p.title == title);
                var like = dbContext.Like.FirstOrDefault(l => l.bookID == product.Id && l.userID == userID);
                dbContext.Like.Remove(like);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// 本のtitleとuserIDを引数に受け取り、まずProductテーブルから該当するtitleと一致するレコードを一つ取得 <summary>
        /// 次にそのレコードのbookIDを取得、後はuserIDとアンパサンドされている値だけを一つ取得する。そのレコードを削除
        public async Task DeleteTemporaryReserveAsync(string title, string userID)
        {
            try
            {
                var product = dbContext.Product.FirstOrDefault(p => p.title == title);
                var reservationTemporary = dbContext.ReservationTemporary.FirstOrDefault(l => l.bookID == product.Id && l.userID == userID);
                dbContext.ReservationTemporary.Remove(reservationTemporary);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}

