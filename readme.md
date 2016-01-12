Panic
====
(Game) Server testing tool.

Client
----
서버와 실질적으로 연결을 맺는 클라이언트입니다.<br>
이는 지속적으로 연결이 유지되는 소켓, 또는 웹소켓일 수도 있고,
매 요청마다 연결이 새로이 맺어지는 HTTP 클라이언트가 될 수도 있습니다.

Protocol.Marshal
----
클라이언트 세션 내에서, 패킷이 어떻게 직렬화되고, 역직렬화되는지 방법을 지정합니다.<br>
클라이언트와 프로토콜 레이어를 분리함으로써, 같은 HTTP 클라이언트를 사용하면서도 서로 다른 패킷 구조를 가지도록 설계하는것이 가능합니다.

```c#
// 클라이언트는 HTTP 클라이언트, 서브 프로토콜은 JSON을 사용합니다.
http = new HttpClient("http://localhost", new JsonSerializer());
// 클라이언트는 HTTP 클라이언트, 서브 프로토콜은 Yml을 사용합니다.
http = new HttpClient("http://localhost", new YamlSerializer());
```

Packet
----

Template
----
템플릿은 테스트에 있어서 단일 유닛입니다.<br>
템플릿에는 리퀘스트 정보, 그리고 해당 리퀘스트를 보냈을 때의 기대 결과값을 가집니다.
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
시나리오는 템플릿의 실행 시퀸스를 지정한 집합입니다.<br>

예를 들어 아래의 시나리오는 로그인을 수행한 후, 랜덤 방향으로 움직이고 공격하고를 3번 반복한 뒤, 로그아웃을 수행합니다.
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
러너는 테스트 '실행'의 단위이자 테스트를 실행시키는 역할을 합니다.

```c#
// someScenario를 10개의 클라이언트로 각각 1000회 실행합니다.
Runner<HttpClient>.ExecuteScenario(
  scenario: someScenario,
  coWorkers: 10, iteration: 1000);
```

DataModel.Contract
----
콘트랙트는 데이터 모델의 각 필드에 값 형식에 대한 검증을 수행합니다.

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
룰은 템플릿의 예상 결과와 실제 결과값에 상이한 부분이 있을 때, 이를 어떻게 처리할 것인지를 지정합니다.

```c#
public class TestRule
{
  // 콘트랙트 실패 -> 테스트 실패로 간주
  public virtual TestResult OnContractFailure()
    => TestResult.Failed;

  // 예상결과에는 없는 필드지만 리스폰스에는 있을 경우 -> 성공(무시)
  public virtual TestResult OnFieldNotExpected()
    => TestResult.Passed;
  // 예상결과에 있는 필드지만 리스폰스에는 없을 경우 -> 실패
  public virtual TestResult OnFieldMissing()
    => TestResult.Failed;
}
```

DataSource
----
데이터 소스는 템플릿, 시나리오등의 테스트 데이터를 제공하는 역할을 합니다.<br>
데이터 소스 인터페이스를 알맞게 재구현하여, 템플릿이나 시나리오를 로컬 파일이 아닌 네트워크에서 읽어오거나,
테스트 시나리오의 포멧을 JSON이 아닌 스크립트로 변경하는등의 행동을 할 수 있습니다.