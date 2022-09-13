def solution(s):
    answer = [0, 0]
    while len(s) > 1:
        zeros, s = toBin(s)
        answer[0] += 1; answer[1] += zeros
    return answer

def toBin(s):
    length = len(s)
    result = s.count('1')
    return length - result, bin(result)[2:]