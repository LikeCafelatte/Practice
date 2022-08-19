def solution(survey, choices):
    score = {'R' : 0, 'T' : 0, 'C' : 0, 'F' : 0, 'J' : 0, 'M' : 0, 'A' : 0, 'N' : 0}
    for i in range(len(survey)):
        score[survey[i][0] if choices[i] < 4 else survey[i][1]] += 4 - choices[i] if choices[i] < 4 else choices[i] - 4
    return ("R" if score['R'] >= score['T'] else "T") + ("C" if score['C'] >= score['F'] else "F") + ("J" if score['J'] >= score['M'] else "M") + ("A" if score['A'] >= score['N'] else "N")
