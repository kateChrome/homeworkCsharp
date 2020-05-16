namespace ConsoleGame
{
    public class Player
    {
        public Map GameMap { set; get; }
        public (int first, int second) Position { set; get; }
        public (int first, int second) LastPosition { set; get; }

        public Player(Map map)
        {
            this.GameMap = map;
            this.Position = map.PlayerStartPosition;
            this.LastPosition = map.PlayerStartPosition;
        }

        /// <summary>
        /// Change player position.
        /// up 00
        /// right 01
        /// left 10
        /// down 11
        /// </summary>
        public bool TakeOneStep((bool, bool) step)
        {
            var newPosition = Position;
            if (step == (false, false))
            {
                newPosition.second--;
            }
            else if (step == (false, true))
            {
                newPosition.first++;
            }
            else if (step == (true, false))
            {
                newPosition.first--;
            }
            else if (step == (true, true))
            {
                newPosition.second++;
            }

            if (!GameMap.IsCorrectPosition(newPosition))
            {
                return false;
            }

            this.LastPosition = Position;
            this.Position = newPosition;
            return true;

        }
    }
}