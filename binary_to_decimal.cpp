#include<iostream>
#include<math.h>
using namespace std;
int main(){
    cout<<"Enter binary to convert it into number"<<endl;
    int n;
    cin>>n;
    int ans=0;
    int i=0;
    while(n!=0){
        int digit=n%10;
        if(digit==1){
            ans=ans+pow(2,i);
        }
        n=n/10;
        i++;
    }
    cout<<"Answer is "<<ans<<endl;
}

//This is a small c++ program which will convert any binary number into decimal number...
