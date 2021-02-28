Esta aplicação foi feita no Visual Studio 2019, utilizando .NET Framework 4.5.2 e windows forms na linguagem de C#.

Nota: para o programa funcionar, você deve ir em DAL.Parametros e alterar a variável "dbFile" para o nome do local em que o banco de dados (ProgramaGoDev.mdf) se encontra, como mostrado na imagem abaixo.

![image](https://user-images.githubusercontent.com/55410027/109436570-e248ad80-79fe-11eb-9a8c-7b81bc8d7720.png)

Ao rodar a aplicação, você vai se deparar com o "Menu" de cadastros, onde poderão ser cadastrados os alunos (pessoas), as salas de eventos, os espaços de café e as ocupações das salas, separados por abas.

![image](https://user-images.githubusercontent.com/55410027/109436464-68b0bf80-79fe-11eb-93d8-e050958f52df.png)

Nesta primeira tela, você irá preencher o Nome e o Sobrenome da pessoa que quer cadastrar e clicar em "Cadastrar novo" e uma MessageBox irá lhe avisar se a requisição deu certo ou não. Logo após isso, a pessoa cadastrada irá aparecer no DataGridView acima, que é onde todas as pessoas cadastradas irão aparecer.

Para excluir um registro de uma pessoa, você irá digitar o ID da pessoa desejada no campo ID e então clicar em "Excluir registro".
(O intuito era permitir que o usuário apenas clicasse duas vezes sobre um registro no DataGridView e todas as informações da pessoa fossem trazidas pros campos abaixo, porém ocorreu um erro que eu não consegui resolver, porém mantive o código comentado.)

Para atualizar um registro de uma pessoa, você irá digitar o ID da pessoa desejada no campo ID e alterar as informações desejadas, e então clicar em "Atualizar registro.

Estes três botões funcionam da mesma forma em todas as abas.

Para pesquisar um registro pelo ID, você precisa digitar o ID do registro desejado no campo ID e então pressionar o botão com o ícone da lupa logo ao lado (imagem abaixo), e então, o(s) registro(s) que se encaixam na consulta, irão aparecer no DataGridView acima.

![image](https://user-images.githubusercontent.com/55410027/109437145-238e8c80-7a02-11eb-9193-b3fbaa5d0296.png)

Há também os botões de "Refresh" e "Limpar tudo" (imagem abaixo) respectivamente. Ao clicar no botão de refresh, as pesquisas serão desfeitas e todos os registros voltarão para o DataGridView.
Já o botão de limpar tudo irá limpar todos os campos que estiverem preenchidos (excluindo o DataGridView e os DateTimePickers).

![image](https://user-images.githubusercontent.com/55410027/109437327-1c1bb300-7a03-11eb-8722-d020b1e2c5a8.png)

Na aba "Salas de evento" (imagem abaixo), é possível cadastrar salas ao preencher o Nome e Lotação correspondentes.

![image](https://user-images.githubusercontent.com/55410027/109437424-8af90c00-7a03-11eb-9367-fd791fc7ea43.png)

Na aba "Espaços de café" (imagem abaixo), é possível cadastrar os espaços de café dos alunos com Lotação, Hora inicial e Hora final.
(Nota: o intuito do DataGridView "Ocupações" era trazer as ocupações dos espaço de café ao clicar duas vezes em um registro no DataGridView acima, porém, como comentado anteriormente, não foi possível.)

![image](https://user-images.githubusercontent.com/55410027/109437466-af54e880-7a03-11eb-864e-27fefe27f9f5.png)

Na aba "Ocupações" (imagem abaixo), é possível registrar cadastros de pessoas nas Salas e Espaços de café, utilizando o ID da pessoa, ID da sala e ID do espaço de café. Obs: não é possível registrar uma ocupação em uma sala que tenha 1 ocupação a mais que a(s) outra(s), fazendo com que ambas salas tenham a mesma quantidade de alunos.

![image](https://user-images.githubusercontent.com/55410027/109437557-22f6f580-7a04-11eb-94fa-2d16d5331ffd.png)
