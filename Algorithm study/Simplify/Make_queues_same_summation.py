def solution(queue1, queue2):
    total = sum(queue1) + sum(queue2)
    answer = 0
    if total % 2 != 0:
        return -1
    target = total / 2
    q = queue1 + queue2
    i1 = 0; i2 = len(queue1)
    
    if max(max(queue1), max(queue2)) > target:
        return -1
    
    sum1 = sum(queue1)
    while sum1 != target:
        if i2 >= len(q):
            return -1
        if sum1 > target:
            sum1 -= q[i1]
            i1 += 1
        else:
            sum1 += q[i2]
            i2 += 1
        answer += 1
    sum1 = sum(queue1)
        
    return answer