# 신고 결과 받기
# https://school.programmers.co.kr/learn/courses/30/lessons/92334?language=python3

def solution(id_list, report, k):
    reports, bans = {id : [] for id in id_list}, {id : 0 for id in id_list}
    for r in set(report):
        reporter, reportee = r.split(' ')
        reports[reporter].append(reportee)
        bans[reportee] += 1
    trolls = [troll for troll in bans.keys() if bans[troll] >= k]
    answer = [sum([1 for r in reports[id] if r in trolls]) for id in id_list]
    return answer