def solution(alp, cop, problems):
    answer = 0
    learning_time = 0#min([max(problem[0] - alp + problem[1] - cop, 0) for problem in problems]) - 1
    learnables = [[0, 0, 1, 0, 1], [0, 0, 0, 1, 1]]
    while len(problems) > 0 :
        #print(learning_time)
        next_step = []
        remain_time = -1
        for learnable in learnables:
            temp_time = 2000#min([max((problem[0] - alp) // learnable[2] + min((problem[0] - alp) % learnable[2], 1), (problem[1] - cop) // learnable[3] + min((problem[1] - cop) % learnable[3], 1), 0) if not (problem[0] - alp > 0 and learnable[2] == 0) or (problem[1] - cop > 0 and learnable[3] == 0) else 2000 for problem in problems]) * learnable[4]
            for problem in problems:
                temp_time = min(temp_time, max((problem[0] - alp) // learnable[2] + min((problem[0] - alp) % learnable[2], 1) if learnable[2] > 0 else 0 if problem[0] - alp <= 0 else 2000, (problem[1] - cop) // learnable[3] + min((problem[1] - cop) % learnable[3], 1) if learnable[3] > 0 else 0 if problem[1] - cop <= 0 else 2000, 0))
            if remain_time < 0 or remain_time > temp_time:
                remain_time = temp_time
                next_step = learnable
        print(remain_time, ", ", alp, ", ", cop, ", ", next_step)
        alp += next_step[2]
        cop += next_step[3]
        learning_time += next_step[4]
        
        for problem in problems:
            if problem[0] <= alp and problem[1] <= cop:
                problems.remove(problem)
                for learnable in learnables:
                    if learnable[2] >= problem[2] and learnable[3] >= problem[3] and learnable[4] <= problem[4]:
                        learnables.remove(learnable)
                if problem[2] >= problem[4] or problem[3] >= problem[4]:
                    learnables.append(problem)
    return learning_time