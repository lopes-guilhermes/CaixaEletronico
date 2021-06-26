# CaixaEletronico

1) - Criar um projeto Console em dotnet que receberá um valor de saque (valor de entrada), o valor de saque deve ser um número inteiro, e aceito conforme cédulas e quantidade disponíveis;

NOTA IMPORTANTE: Utilizar sempre a maior quantidade de cédula de maior valor e retornar a quantidade de cada cédula utilizada para saque. 

EXEMPLO SAQUE 375 REAIS: 3 cédula de 100, 1 cédula de 50, 1 cédula de 20 reais e 1 cédula de 5 reais.
EXEMPLO SAQUE 188 REAIS: 1 cédula de 100, 1 cédula de 50, 1 cédula de 20 reais, 1 cédula de 10 reais e 4 cédulas de 2 reais.
EXEMPLO SAQUE 77  REAIS: 1 cédula de 50 , 1 cédula de 20, 1 cédula de 5 reais, e 1 cédulas de 2 reais.

A) TESTE 1 - NOTAS DISPONIVEIS: [100, 50, 20] 
- Aceitar apenas valores que conseguimos retornar o valor de saque conforme cédulas disponíveis, por exemplo (150, 120, 170) e não podendo aceitar por exemplo (1, 5, 19, 130,80, 60, 75) entre outros.

B) TESTE 2 - NOTAS DISPONIVEIS: [100, 50, 20, 10, 5] 
- Aceitar apenas valores que conseguimos retornar o valor de saque conforme cédulas disponíveis, por exemplo (175, 110, 80, 75, 105) e não podendo aceitar por exemplo (1, 42, 102, 199, 88) entre outros.

C) TESTE 3 - NOTAS DISPONIVEIS: [100, 50, 20, 10, 5, 2] 
- Aceitar apenas valores que conseguimos retornar o valor de saque conforme cédulas disponíveis, por exemplo (2, 7, 15, 77, 99, 88, 150, 380) e não podendo aceitar por exemplo (1).

2) - Orientar os testes com Principios Orientação a Objetos e SOLID.
