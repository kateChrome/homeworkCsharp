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
        /// <param name="size">maximum value of hash</param>
        /// <returns></returns>
        int Hash(string data, int size);
    }
}