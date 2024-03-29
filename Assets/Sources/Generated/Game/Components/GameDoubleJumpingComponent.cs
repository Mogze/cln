//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly cln.DoubleJumpingComponent doubleJumpingComponent = new cln.DoubleJumpingComponent();

    public bool isDoubleJumping {
        get { return HasComponent(GameComponentsLookup.DoubleJumping); }
        set {
            if (value != isDoubleJumping) {
                var index = GameComponentsLookup.DoubleJumping;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : doubleJumpingComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherDoubleJumping;

    public static Entitas.IMatcher<GameEntity> DoubleJumping {
        get {
            if (_matcherDoubleJumping == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.DoubleJumping);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherDoubleJumping = matcher;
            }

            return _matcherDoubleJumping;
        }
    }
}
