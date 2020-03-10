namespace ProgramSources
{
    /// <summary>
    /// Hash interface
    /// </summary>
    public interface IHash
    {
        /// <summary>
        /// Get hash value of input data
        /// </summary>
        /// <param name="data">input data</param>
        int Hash(string data);
    }
}