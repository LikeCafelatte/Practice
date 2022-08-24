def solution(alp, cop, problems):
    alp_max = max([problem[0] for problem in problems])
    cop_max = max([problem[1] for problem in problems])
    dp = [[x + y for x, y in zip([c - cop if cop < c else 0 for c in range(cop_max+1)], [a - alp if alp < a else 0] * max(alp_max+1, cop_max + 1))] for a in range(alp_max+1)]

    for i in range(alp if alp < alp_max else alp_max, alp_max + 1):
        for j in range(cop if cop < cop_max else cop_max, cop_max + 1):
            for problem in problems:
                if i>= problem[0] and j>= problem[1]:
                    dp[min(i + problem[2], alp_max)][min(j + problem[3], cop_max)] = min(dp[min(i + problem[2], alp_max)][min(j + problem[3], cop_max)], dp[i][j] + problem[4])

    return dp[alp_max][cop_max]
