console.log(1214);
console.log("1214");

async function l() {
    const responsen = await fetch("http://localhost:5223/api/App");
    //����� ����� �� ��������� ����� ������
    const jsonsData = await responsen.json();
    console.log(jsonsData);
}
l()
////����� ����� �� ��������� ����� ������
//var all = await s.GetAll();
//all.ForEach(all => Console.WriteLine(all));

