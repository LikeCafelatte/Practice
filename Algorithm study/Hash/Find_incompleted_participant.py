def solution(participant, completion):
    p_dict = {}
    for p in participant:
        if p in p_dict.keys():
            p_dict[p] += 1
        else:
            p_dict[p] = 1
    for c in completion:
        p_dict[c] -= 1
    return sorted(p_dict.items(), key = lambda item: item[1], reverse = True)[0][0]