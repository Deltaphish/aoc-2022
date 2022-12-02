public class Part01 : ISolver {
    public string Run(string input)
    {
      int score = 0;
      string[] matches = input.Split('\n');
      foreach (string m in matches)
      {
        score += this.resolve_fight(m) + this.hand_score(m);
      }
      return score.ToString();
    }

    private int resolve_fight(string match)
    {
        int opponent = match[0] - 65;
        int player = match[2] - 88;
        if((opponent + 1) % 3 == player)
        {
            return 6;
        }
        else if(player == opponent)
        {
            return 3;
        }
        return 0;
    }

    private int hand_score(string match)
    {
        switch (match[2])
        {
            case 'X':
                return 1;
            case 'Y':
                return 2;
            case 'Z':
                return 3;
            default:
                throw new Exception("Invalid input");
        }
    }
}