import itertools
def solution(info, query):
    info = [i.split(' ') for i in info]
    info_dict = {"".join(key) : [] for key in itertools.product(*[['cpp', 'java', 'python'], ['backend', 'frontend'], ['junior', 'senior'], ['chicken', 'pizza']])}
    for jp, bf, js, cp, score in info:
        info_dict["".join([jp, bf, js, cp])].append(int(score))
    for val in info_dict.values():
        val.sort()
    answer = []
    for jp, bf, js, cp, score in [q.replace(' and', '').split(' ') for q in query]:
        result = 0
        for key in itertools.product(*[[jp] if jp != '-' else ['cpp', 'java', 'python'], [bf] if bf != '-' else ['backend', 'frontend'], [js] if js != '-' else ['junior', 'senior'], [cp] if cp != '-' else ['chicken', 'pizza']]):
            arr = info_dict["".join(key)]; score = int(score)
            high = len(arr); low = 0; mid = (high + low) // 2
            while high > low:
                if arr[mid]  >= score:
                    high = mid; mid = (high + low) // 2
                else:
                    low = mid + 1; mid = (high + low) // 2
            result += len(arr) - low
        answer.append(result)
    return answer