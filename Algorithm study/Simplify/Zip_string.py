def solution(s):
    answer = len(s)
    for length in range(1, len(s) // 2 + 1):
        new_str = ""
        temp = s[:length]
        count = 1
        for i in range(length, len(s) + length, length):
            if temp == s[i : i + length]:
                count += 1
            else:
                new_str = new_str + str(count) + temp if count > 1 else new_str + temp
                count = 1
            temp = s[i : i + length]
        answer = min(answer, len(new_str))

    return answer
