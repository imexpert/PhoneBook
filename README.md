<h1>Phone Book Application using Microservices</h1>

<p>Projelerin çalıştığı portlar <b>Ports.txt</b> dosyasının içerisinde kayıt altında tutuluyor.</p>
<p>Uygulama dockerize edilerek ayağa kaldırılıyor.</p>
<p>Kullanılan teknolojiler aşağıdaki gibidir;</p>
<ol>
  <li> .Net 5.0 kullanılmıştır.</li>
  <li> Database olarak <b>Postgres</b> tercih edilmiştir.</li>
  <li> Kuyruklama mekanızması için <b>RabbitMQ</b> kullanılmıştır.</li>
  <li> UI ile asenkron haberleşme için <b>SignalR</b> ve bağlantıları tutması için de <b>Redis</b> kullanışmıştır.</li>
  <li> Book ve Report olmak üzere 2 adet microservice içermektedir.</li>
  <li> Gateway olarak <b>Ocelot</b> kütüphanesi tercih edilmiştir.</li>
</ol>

<p><b>Proje Migration Ayarları;</b></p>
<ol>
  <li>Startup Projesi olarak <b>PhoneBook.Libraries.Book.Api</b> seçilir.</li>
  <li>Package Manager Console açılır.</li>
  <li>Package Manager Console içerisinden default proje olarak <b>PhoneBook.Libraries.Book.DataAccess</b> projesi seçilir.</li>
  <li>Proje Envrinment değişkeni <b>$env:ASPNETCORE_ENVIRONMENT='Production'</b> komutu ile ayarlanır.</li>
  <li><b>Add-Migration InitialCreate -Context ProjectDbContext -OutputDir Migrations/Pg</b> komut ile ilk migration oluşturulur.</li>
  <li>Yapılan değişiklikler <b>Update-Database -context ProjectDbContext</b> komut ile database'e gönderilir.</li>
</ol>

<b>Projeyi Çalıştırmak için;</b><br>
<ol>
  <li>Proje ana dizinindeyken <b>"docker-compose up"</b> diyerek bütün docker image'larını yüklüyoruz.</li>
</ol>
