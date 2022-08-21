def solution(queue1, queue2):
    total = sum(queue1) + sum(queue2)
    q = [[queue1[:], queue2[:], 0]]
    past_list = []
    answers = []
    if total % 2 != 0:
        return -1
    target = total / 2
    
    if max(max(queue1), max(queue2)) > target:
        return -1
    
    while len(q) > 0:
        dq = q.pop(0)
        if dq[0] in past_list or (len(answers) > 0 and dq[2] > min(answers)):
            continue
        if sum(dq[0]) == target:
            answers.append(dq[2])
        past_list.append(dq[0])
        if len(dq[0]) > 0:
            new_q1 = dq[0][:]
            new_q2 = dq[1][:]
            new_q2.append(new_q1.pop(0))
            q.append([new_q1, new_q2, (dq[2] + 1)])
        if len(dq[1]) > 0:
            new_q1 = dq[0][:]
            new_q2 = dq[1][:]
            new_q1.append(new_q2.pop(0))
            q.append([new_q1, new_q2, (dq[2] + 1)])
        
    return min(answers) if len(answers) > 0 else -1