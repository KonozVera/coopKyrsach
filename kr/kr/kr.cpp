#include <iostream>
using namespace std;

int main()
{
    setlocale(LC_ALL, "Russian");
    int P1 = 0, P2 = 0, K = 1000, A = 0, B = 0, coast1 = 0, coast2 = 0;
    cout << "Введите, пожалуйста, стоимоть изделия типа А: ";
    cin >> coast1;
    cout << "Введите, пожалуйста, стоимоть изделия типа В: ";
    cin >> coast2;
    cout << "Введите, пожалуйста, кол-во штук изделий типа А: ";
    cin >> A;
    cout << "Введите, пожалуйста, кол-во штук изделий типа В: ";
    cin >> B;
    P1 = A * 24;
    P2 = B * 24;
    if (K <= 1000)
    {
        if (coast1 * P1 >= coast2 * P2)
        {
            cout << "Максимальная прибиль от продаж изделий типа А: ";
        }
        if (coast1 * P1 <= coast2 * P2)
        {
            cout << "Максимальная прибиль от продаж изделий типа В: ";
        }
    }
    else
        cout << "Ошибка!!!";
}