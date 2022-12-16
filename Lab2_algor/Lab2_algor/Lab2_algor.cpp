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
void rememberMinCost(int idx, int* S) {
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

void getMinimalCosts(int idx, int M, int* F, int* B, int* C, int* S, int MF, int MB, int MC) {
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

    ofstream out("result.txt");

    out << "В связи с открытием олимпиады N человек (N < 11) решили устроить вечеринку.";
    out << "Для ее проведения достаточно купить MF бутылок фанты, MB бананов, MC тортов.";
    out << "При покупке определенных наборов товаров действуют правила оптовой торговли: стоимость наборы товара может отличаться от суммарной стоимости отдельных частей.";
    out << "Написать программу, вычисляющую по исходным данным, минимальный взнос участника вечеринки V." << endl << endl;

    // открываем файл
    ifstream in("Предложения.txt");
    if (!in.is_open()) {
        exit('0');
    }

    // Для каждого тестого набора сначала выводим входные данные
    // а затем выводим результат нашей функции
   
	int N, M;
	in >> N >> M;

	int* F = new int[M];
	int* B = new int[M];
	int* C = new int[M];
	int* S = new int[M];

	for (int i = 0; i < M; i++) {
		in >> F[i] >> B[i] >> C[i] >> S[i];
	}

	int MF;
	int MB;
	int MC;

	in >> MF >> MB >> MC;


	out << "Входные данные: " << endl;
	out << N << " - количество человек на вечеринке" << endl;
	out << M << " - количество оптовых наборов" << endl;
	out << "Перечисление наборов: " << endl;
	for (int i = 0; i < M; i++) {
		out << F[i] << " " << B[i] << " " << C[i] << " " << S[i] << endl;
	}
    cout << endl;

	out << "Количество необходимых элементов в наборе: " << endl;
	out << MF << " " << MB << " " << MC << endl;

	out << "Минимальные затраты на одного человека: " << endl;
	getMinimalCosts(0, M, F, B, C, S, MF, MB, MC);
	out << minSum / N << endl << endl;

    delete F;
    delete B;
    delete C;
    delete S;
}