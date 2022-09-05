def solution(str1, str2):
    str1 = str1.lower(); str2 = str2.lower()
    str1 = [str1[i] + str1[i + 1] for i in range(len(str1) - 1) if str1[i].isalpha() and str1[i + 1].isalpha()]
    str2 = [str2[i] + str2[i + 1] for i in range(len(str2) - 1) if str2[i].isalpha() and str2[i + 1].isalpha()]
    count = 0
    for s in str1:
        if s in str2:
            count += 1
            str2.remove(s)
    return 65536 if len(str1) + len(str2) == 0 else int(65536 * count / (len(str1) + len(str2)))
