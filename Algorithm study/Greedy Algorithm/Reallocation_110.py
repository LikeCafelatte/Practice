def solution(s):
    answer = [exchange(num) for num in s]
    return answer

def exchange(s):
    temp = remove110(s)
    idx = temp.find('11')
    if idx == -1 and len(temp) > 0 and temp[-1] == '0':
        idx = len(temp)
    result = temp[:idx] + "110" * ((len(s) - len(temp)) // 3) + temp[idx:] 
    return result

def remove110(s):
    if not '110' in s:
        return s
    temp, zero, one, last = [], 0, 0, ''
    for c in s:
        if c == '0':
            zero += 1
        else:
            if c != last:
                if one >= 2 * zero:
                    zero, one = 0, one - 2 * zero
                else:
                    zero, one = zero - one // 2 , one % 2
                    temp.append('1' * one + '0' * zero)
                    zero, one = 0, 0
            one += 1
        last = c
    zero, one = (0, one - 2 * zero) if one > 2 * zero else (zero - one // 2 , one % 2)
    temp.append('1' * one + '0' * zero)
    return "".join(temp)
