public class Part02 : ISolver {
    public string Run(string input)
    {
      int score = 0;
      string[] matches = input.Split('\n');
      foreach (string match in matches)
      {
        string m = this.rig_match(match);
        score += this.resolve_fight(m) + this.hand_score(m);
      }
      return score.ToString();
    }

    private string rig_match(string match)
    {
        string m = match.Substring(0,2);
        switch(match[2])
        {
            case 'X':
                m += (char)((((match[0] - 65) + 2) % 3) + 88);
                break;
            case 'Y':
                m += (char) (match[0] + 23);
                break;
            case 'Z':
                m += (char)((((match[0] - 65) + 1) % 3) + 88);
                break;
        }
        return m;
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
                throw new Exception("Invalid input: " + match);
        }
    }
}