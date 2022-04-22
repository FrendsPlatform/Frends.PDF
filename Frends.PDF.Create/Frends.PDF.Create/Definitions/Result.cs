namespace Frends.PDF.Create.Definitions
{
    /// <summary>
    /// Result-class for the task.
    /// </summary>
    public class Result
    {
        /// <summary>
        /// Indicates if the operation was successful.
        /// </summary>
        public bool Success { get; private set; }

        /// <summary>
        /// Name of the file which was created.
        /// </summary>
        public string FileName { get; private set; }

        internal Result(bool success, string fileName)
        {
            Success = success;
            FileName = fileName;
        }
    }
}
