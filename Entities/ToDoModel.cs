using System.ComponentModel.DataAnnotations;

namespace Task3.Entities
{
    /// <summary> 
    /// 題名　（必須）文字列
    /// 期限 （必須）日付
    /// 状態 （必須）選択入力（0.未着手、1.仕掛中、2.完了、9.無視） 
    /// 内容 文字列（改行あり） 
    /// </summary>
    public class ToDoModel : IComparable<ToDoModel>
    {
        private int _status;

        public static readonly (int No, string Name)[] Statuses = {
            (No: 0, Name: "未着手"),
            (No: 1, Name: "仕掛中"),
            (No: 2, Name: "完了"),
            (No: 9, Name: "無視")
        };
        
        public string Id { get; set; } = System.Guid.NewGuid().ToString();

        [Required(ErrorMessage = "タイトルは必須です。")]
        public string? Title { get; set; }
        [Required(ErrorMessage = "期限は必須です。")]
        public DateTime Deadline { get; set; } = DateTime.Now;
        [Required(ErrorMessage = "ステータスは必須です。")]
        //ステータスをセットする際にStatusesに存在するintが指定されたか確認する。
        public int Status
        {
            get => _status;
            set
            {
                if (Statuses.Any(x => x.No == value))
                {
                    _status = value;
                }
                else
                {
                    throw new ArgumentException("ステータスが不正です。");
                }
            }
        }

        [Required(ErrorMessage = "内容は必須です。")]
        public string? Content { get; set; }

        /// <summary>
        /// ToDoModelのプロパティを比較するメソッド
        /// </summary>
        /// <param name="other">比較対象のToDoModel</param>
        /// <returns>比較結果を示す整数</returns>
        public int CompareTo(ToDoModel? other)
        {
            if (other == null) return 1;

            // Statusで比較
            int statusComparison = Status.CompareTo(other.Status);
            if (statusComparison != 0) return statusComparison;

            // Deadlineで比較
            return string.Compare(Deadline.ToString(), other.Deadline.ToString(), StringComparison.Ordinal);
        }

        public ToDoModel Clone()
        {
            return new ToDoModel
            {
                Id = Id,
                Title = Title,
                Deadline = Deadline,
                Status = Status,
                Content = Content
            };
        }
    }
}
