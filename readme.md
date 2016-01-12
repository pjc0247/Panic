Panic
====
(Game) Server testing tool.

Client
----
������ ���������� ������ �δ� Ŭ���̾�Ʈ�Դϴ�.<br>
�̴� ���������� ������ �����Ǵ� ����, �Ǵ� �������� ���� �ְ�,
�� ��û���� ������ ������ �ξ����� HTTP Ŭ���̾�Ʈ�� �� ���� �ֽ��ϴ�.

Protocol.Marshal
----
Ŭ���̾�Ʈ ���� ������, ��Ŷ�� ��� ����ȭ�ǰ�, ������ȭ�Ǵ��� ����� �����մϴ�.<br>
Ŭ���̾�Ʈ�� �������� ���̾ �и������ν�, ���� HTTP Ŭ���̾�Ʈ�� ����ϸ鼭�� ���� �ٸ� ��Ŷ ������ �������� �����ϴ°��� �����մϴ�.

```c#
// Ŭ���̾�Ʈ�� HTTP Ŭ���̾�Ʈ, ���� ���������� JSON�� ����մϴ�.
http = new HttpClient("http://localhost", new JsonSerializer());
// Ŭ���̾�Ʈ�� HTTP Ŭ���̾�Ʈ, ���� ���������� Yml�� ����մϴ�.
http = new HttpClient("http://localhost", new YamlSerializer());
```

Packet
----

Template
----
���ø��� �׽�Ʈ�� �־ ���� �����Դϴ�.<br>
���ø����� ������Ʈ ����, �׸��� �ش� ������Ʈ�� ������ ���� ��� ������� �����ϴ�.
```json
{
  "uri" : "/login",

  "request" : {
    "id" : "pjc0247",
    "password" : "asdfasdf"
  },

  "response" : {
    "nickname" : "joe"
  }
}
```

Scenario
----
�ó������� ���ø��� ���� �������� ������ �����Դϴ�.<br>

���� ��� �Ʒ��� �ó������� �α����� ������ ��, ���� �������� �����̰� �����ϰ� 3�� �ݺ��� ��, �α׾ƿ��� �����մϴ�.
```json
[
  "login",

  "$iter" : [
    3,
    "$pick" : [
      "move_left", "move_right",
      "move_up", "move_down"
    ],
    "attack"
  ],

  "logout"
]
```

Runner
----
���ʴ� �׽�Ʈ '����'�� �������� �׽�Ʈ�� �����Ű�� ������ �մϴ�.

```c#
// someScenario�� 10���� Ŭ���̾�Ʈ�� ���� 1000ȸ �����մϴ�.
Runner<HttpClient>.ExecuteScenario(
  scenario: someScenario,
  coWorkers: 10, iteration: 1000);
```

DataModel.Contract
----
��Ʈ��Ʈ�� ������ ���� �� �ʵ忡 �� ���Ŀ� ���� ������ �����մϴ�.

```c#
class Foo
{
  //[Panic.Test.DataModel.StringRange(1, 1)]
  [Panic.Test.DataModel.NotNull]
  public string Name;
}
```

Rule
----
���� ���ø��� ���� ����� ���� ������� ������ �κ��� ���� ��, �̸� ��� ó���� �������� �����մϴ�.

```c#
public class TestRule
{
  // ��Ʈ��Ʈ ���� -> �׽�Ʈ ���з� ����
  public virtual TestResult OnContractFailure()
    => TestResult.Failed;

  // ���������� ���� �ʵ����� ������������ ���� ��� -> ����(����)
  public virtual TestResult OnFieldNotExpected()
    => TestResult.Passed;
  // �������� �ִ� �ʵ����� ������������ ���� ��� -> ����
  public virtual TestResult OnFieldMissing()
    => TestResult.Failed;
}
```

DataSource
----
������ �ҽ��� ���ø�, �ó��������� �׽�Ʈ �����͸� �����ϴ� ������ �մϴ�.<br>
������ �ҽ� �������̽��� �˸°� �籸���Ͽ�, ���ø��̳� �ó������� ���� ������ �ƴ� ��Ʈ��ũ���� �о���ų�,
�׽�Ʈ �ó������� ������ JSON�� �ƴ� ��ũ��Ʈ�� �����ϴµ��� �ൿ�� �� �� �ֽ��ϴ�.