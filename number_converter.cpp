/*This a c++ program which can convert a decimal number into a binary number 
and a binary number into a decimal number...*/

#include<iostream>
#include<math.h>
using namespace std;
void binary_to_decimal(){
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
void decimal_to_binary(){
    cout<<"Enter number to convert it into binary"<<endl;
    int n;
    cin>>n;
    int ans=0;
    int i=0;
    while(n!=0){
        int bit=n&1;
        ans=(bit*pow(10,i))+ans;
        n=n>>1;
        i++;
    }
    cout<<"Answer is " <<ans<<endl;

}


int main(){

    cout<<"Welcome to binary and decimal converter Program"<<endl;
    cout<<"Please Enter Your Choice"<<endl<<"1.Convert Binary into Decimal"<<endl<<"2.Convert Decimal into Binary"<<endl;
    int ch;
    cin>>ch;
     
    switch(ch){

        case 1:  
                    binary_to_decimal();
                    break;
        case 2:  
                    decimal_to_binary();
                    break; 
        default:
                    cout<<"Enter a valid option!"<<endl;
                     break;   

    }
}
