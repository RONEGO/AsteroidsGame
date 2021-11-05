using UnityEngine.UI;
using UnityEngine;

    public class Score : MonoBehaviour
    {
        int score;
        Text Score_;

        public int score_get
        {
            get
            {
                return score;
            }
            set
            {
                score = value;
                RefClass.score = score;
                if (Score_ != null)
                    Score_.text = "Score " + score;
            }
        }

        public void Starting()
        {
            Score_ = GameObject.Find("Score").GetComponent<Text>();
            score_get = 0;
        }
    }


