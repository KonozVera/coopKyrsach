#include <iostream>
#include <fstream>
#include <vector>

using namespace std;

vector<int> combination;
int minSum = 0;

/*
    M - count of kits
    F - array of fantas
    B - array of bananas
    C - array of cakes
    S - array of costs
*/
void rememberMinCost(int idx, int S[]) {
    if (minSum == 0) {
        for (int i = 0; i < idx; i++) {
            minSum += S[combination[i]];
        }
    }
    else {
        int tempMinSum = 0;
        for (int i = 0; i < idx; i++) {
            tempMinSum += S[combination[i]];
        }
        if (tempMinSum < minSum) {
            minSum = tempMinSum;
        }
    }
}

void getMinimalCosts(int idx, int M, int F[], int B[], int C[], int S[], int MF, int MB, int MC) {
    if (MF <= 0 && MB <= 0 && MC <= 0) {
        rememberMinCost(idx, S);
        return;
    }
    if (idx == 10) {
        return;
    }
    for (int i = 0; i < M; i++) {
        if ((MF > 0 && F[i] > 0) || (MB > 0 && B[i] > 0) || (MC > 0 && C[i] > 0)) {
            combination[idx] = i;
            getMinimalCosts(idx + 1, M, F, B, C, S, MF - F[i], MB - B[i], MC - C[i]);
        }
        if (MF - F[i] <= 0 && MB - B[i] <= 0 && MC - B[i] <= 0) {
            return;
        }
    }
}

int main()
{

    combination = vector<int>(10);
    int N, M;
    N = 2;
    M = 3;
    int F[] = { 1, 2, 2 };
    int B[] = { 1, 2, 4 };
    int C[] = { 1, 2, 2 };
    int S[] = { 500, 900, 1050 };

    int MF = 7;
    int MB = 2;
    int MC = 1;
    getMinimalCosts(0, M, F, B, C, S, MF, MB, MC);
}