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
        public required string Title { get; set; }
        public required DateTime Deadline { get; set; }
        public required int Status { get; set; }
        public required string Content { get; set; }

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
    }
}
