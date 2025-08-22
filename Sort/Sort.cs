namespace SortLibray;

public static class Sort
{
    public enum SortingRule
    {
        Ascending,
        Descending
    }

    /*
        [루프 불변성]

        부분 배열 array[0:i + 1]은 정렬된 상태이다.
        나머지 부분 배열 array[i + 1:n]은 정렬되지 않은 상태

        i가 1일때, array[0:i - 1] 부분 배열은 요소가 하나로 정렬되어 있다.
        i가 증가하더라도 array[0:i - 1] 부분 배열은 정렬된다.
        루프가 종료되면 array[0:i - 1]에 n + 1을 대입하더라도 정렬됨이 보장된다.
    /*
        [삽입 정렬 속도 분석]

        최선의 경우
        - 입력된 배열이 이미 정렬되어 있다.
        - O(n)

        최악의 경우
        - 입력된 배열이 역순으로 정렬되어 있다.
        - O(n^2)
    */
    // 이진 검색을 이용한 삽입 정렬
    static public void BinaryInsertionSort(int[] array)
    {
        for (int i = 1; i < array.Length; i++)
        {
            int key = array[i];
            int left = 0;
            int right = i - 1;

            // 이진 검색으로 key가 들어갈 위치 찾기
            while (left <= right)
            {
                int mid = (left + right) / 2;
                if (array[mid] > key)
                    right = mid - 1;
                else
                    left = mid + 1;
            }

            // left가 key의 삽입 위치
            for (int j = i - 1; j >= left; j--)
                array[j + 1] = array[j];

            array[left] = key;
        }
    }

    static public void InsertSort(int[] array)
    {
        for (int i = 1; i < array.Length; i++)
        {
            int key = array[i];

            int j = i - 1;
            while (j >= 0 && array[j] > key)
            {
                array[j + 1] = array[j];
                j--;
            }

            array[j + 1] = key;
        }
    }

    /*
        [삽입 정렬 재귀 점화식]
        T(n) = T(n - 1) + O(n)
    */
    static public void InsertSort2(int[] array, int keyIdx)
    {
        if (keyIdx >= array.Length)
            return;

        int key = array[keyIdx];
        int j = keyIdx - 1;

        while (j >= 0 && array[j] > key)
        {
            array[j + 1] = array[j];
            j--;
        }

        array[j + 1] = key;

        InsertSort2(array, keyIdx + 1);
    }

    /*
        [루프 불변성]

        부분 배열 array[0:i + 1]은 정렬된 상태이다.
        나머지 부분 배열 array[i + 1:n]은 정렬되지 않은 상태

        i가 1일때, array[0:i - 1] 부분 배열은 요소가 하나로 정렬되어 있다.
        i가 증가하더라도 array[0:i - 1] 부분 배열은 정렬된다.
        루프가 종료되면 array[0:i - 1]에 n + 1을 대입하더라도 정렬됨이 보장된다.

        [선택 정렬 속도 분석]

        최선의 경우
        - 입력된 배열이 정렬되어 있더라도 항상 부분 배열을 모두 순회한다.
        - O(n^2)

        최악의 경우
        - 입력된 배열이 정렬되어 있지않더라도 항상 부분 배열을 모두 순회한다.
        - O(n^2)

    */
    static public void SelectionSort(int[] array)
    {
        for (int i = 0; i < array.Length - 1; i++)
        {
            int keyIdx = i;

            for (int j = i + 1; j < array.Length; j++)
            {
                if (array[keyIdx] > array[j])
                    keyIdx = j;
            }

            if (i != keyIdx)
                (array[keyIdx], array[i]) = (array[i], array[keyIdx]);
        }
    }

    static public void MergeSort(int[] A, int start, int end)
    {
        if (start >= end)
            return;

        int middle = (start + end) / 2;
        MergeSort(A, start, middle);
        MergeSort(A, middle + 1, end);

        Merge(A, start, middle, end);
    }

    /*
        [루프 불변성]
        초기화 : 부분 배열A[start:idx]는 요소가 하나로 정렬된 상태이다.
        유지 : 부분 배열 A[start:idx]는 루프 중에 정렬된 상태를 유지한다.
        종료 : 루프가 종료되더라도 A[start:idx]는 정렬된 상태이다.

        만약 nL이나 nR중 비어있지 않은 배열은 이미 정렬되어 있으므로 A에 복사한다.
    */
    static private void Merge(int[] A, int start, int middle, int end)
    {
        int[] nL = new int[middle - start + 1];
        int[] nR = new int[end - middle];

        for (int i = 0; i < nL.Length; i++)
            nL[i] = A[i + start];

        for (int i = 0; i < nR.Length; i++)
            nR[i] = A[i + middle + 1];

        int lIdx = 0;
        int rIdx = 0;
        int idx = start;

        while (lIdx < nL.Length && rIdx < nR.Length)
        {
            if (nL[lIdx] <= nR[rIdx])
                A[idx] = nL[lIdx++];
            else
                A[idx] = nR[rIdx++];

            idx++;
        }

        while (lIdx < nL.Length)
        {
            A[idx++] = nL[lIdx++];
        }

        while (rIdx < nR.Length)
        {
            A[idx++] = nR[rIdx++];
        }
    }

    /*
        [루프 불변성]
        초기화 : 부분 배열A[0:i]는 요소가 하나로 정렬된 상태이다.
        유지 : 부분 배열 A[0:idx]는 루프 중에 정렬된 상태를 유지한다.
        종료 : 루프가 종료되면 A[0:array.Length]는 정렬된 상태이다.

        [시간 복잡도]
        최악, 최선 모두 O(n^2)
    */
    static public void BubbleSort(int[] array)
    {
        for (int i = 0; i < array.Length - 1; i++)
        {
            for (int j = array.Length - 1; j > i; j--)
            {
                if (array[j] < array[j - 1])
                    (array[j], array[j - 1]) = (array[j - 1], array[j]);
            }
        }
    }
}