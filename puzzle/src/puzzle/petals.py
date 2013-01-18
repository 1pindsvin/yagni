NUMBER_OF_CORRECT_ANSWERS_IN_ROW = 2

def petals():
    import random
    def roll():
        dices = [random.randrange(1, 7) for _ in xrange(5)]
        answer = sum(d - 1 for d in dices if (d % 2) != 0)
        return dices, answer
    info = ["Let's play 'Petals Around The Rose.'",
            "The name of the game is significant.",
            "At each turn I will roll five dice,",
            "then ask you for the score, which",
            "will always be zero or an even number.",
            "After you guess the score, I will tell",
            "you if you are right, or tell you the",
            "correct score if you are wrong. The game",
            "ends when you prove that you know the",
            "secret by guessing the score correctly",
            "six times in a row.\n"]
    note = ["Congratulations! You are now a member",
            "of the Fraternity of the Petals Around",
            "The Rose. You must pledge never to",
            "reveal the secret to anyone."]
    state, what = "The five dice are: %s.", "What is the score? "
    yes, no = "Correct.\n", "The correct score is %d.\n"
    c = 0
    print('\n'.join(info))
    while c < NUMBER_OF_CORRECT_ANSWERS_IN_ROW:
        turn, ans = roll()
        print(state % ' '.join(str(d) for d in turn))
        if int(raw_input(what)) == ans:
            print(yes)
            c += 1
        else:
            c = 0
            print(no % ans)
    print('\n'.join(note))



if __name__ == '__main__':
    petals()
    pass
