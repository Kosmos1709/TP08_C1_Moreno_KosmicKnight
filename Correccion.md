# Corrección, Trabajo Práctico N°08 (Platformer 2D)

- **Alumno/a:** Moreno (Joel Nicolas Moreno)
- **Entrega:** `TP08_C1_Moreno_KosmicKnight`
- **Materia:** Programación con Motores de Videojuegos I
- **Nota TP08:** 7

> Las líneas que cito son las de tus archivos con mis comentarios de corrección ya insertados.

## 1. Checklist de requisitos

### General

| #  | Requisito | Estado | Evidencia |
|----|-----------|--------|-----------|
| G1 | Repositorio `TP08_C1_Apellido_Titulo` | ✓ | La carpeta y el remoto de `.git/config` se llaman `TP08_C1_Moreno_KosmicKnight` |
| G2 | Proyecto de Unity con el mismo nombre | ✓ | `ProjectSettings/ProjectSettings.asset:16` `productName: TP08_C1_Moreno_KosmicKnight` |
| G3 | Al menos 2 escenas: MainMenu y Gameplay | ✓ | `ProjectSettings/EditorBuildSettings.asset` tiene `MainMenu.unity` y `Gameplay.unity`. El paso de MainMenu a Gameplay está en `MenuAccion.OnButtonStartClick` (`MenuAcctions.cs:51`) |
| V1 | Publicado en Itch.io y presentable | ✓ | Está publicado en itch.io (revisado el 2026-11-16) |
| V2 | Itch.io jugable en web y descargable para Windows | ✓ | Carga la build web y tiene descarga para Windows |

### Jugador

| #  | Requisito | Estado | Evidencia |
|----|-----------|--------|-----------|
| J1 | Se mueve a derecha e izquierda | ✓ | `Assets/Scripts/Gameplay/Player/MovimentPlayer.cs:47-53` |
| J2 | Salta | ✓ | `MovimentPlayer.cs:58-77`, con doble salto por pickup |
| J3 | Puede dañar enemigos | ✓ | Melee por la layer `Mele` (`AtackPlayer.cs:61`, `InteractionsEnemy.cs:20-25`) y proyectil (`InteractionsEnemy.cs:43-47`) |
| J4 | Barra de vida | ✓ | `Slider Life` en `Gameplay.unity`, `HealBarPlayer.cs:11` |
| J5 | Puede curarse | ✓ | `Assets/Scripts/Gameplay/Pickeable/HealingPickScript.cs`, `AbstractPickeable.ActivationMoreHeal` |
| J6 | Todas las acciones animadas y con sonido | Parcial | Run, Jump, Jump Fall, Atack y Die están animados en `Player.controller`. Caminar, atacar, disparar, perder y ganar suenan; el salto no tiene sonido (`MovimentPlayer.cs:68`) |

### Enemigos

| #  | Requisito | Estado | Evidencia |
|----|-----------|--------|-----------|
| E1 | Dañan al jugador | ✓ | `HealBarPlayer.cs:36-42`, colisión con la layer `Enemy` |
| E2 | Poseen barra de vida | ✗ | `Golem Prefab.prefab` no tiene Slider ni UI; `StatsEnemy.health` no se muestra (`StatsEnemy.cs:11`) |
| E3 | Feedback visual al morir (partículas + animación) | Parcial | Tenés la animación `Die.anim` con el evento `DestroyObject`, pero no hay `ParticleSystem` en el prefab (`StatsEnemy.cs:37`) |
| E4 | Todas sus acciones animadas y con sonido | Parcial | Walk, atack, Hurt y Die están animados. El ataque reproduce `deadSound` (`StatsEnemy.cs:82`) y la caminata no tiene sonido |

### Pickables

| #  | Requisito | Estado | Evidencia |
|----|-----------|--------|-----------|
| K1 | Heal | ✓ | `Assets/Prefabs/Pickeable/Healing Prefab.prefab` con `HealingPickScript` |
| K2 | Damage (aumenta daño) | Parcial | `More Damage Prefab.prefab` usa `ActiveProyectileScript`, que habilita el ataque a distancia pero no modifica `Damage` |
| K3 | Invulnerability por x segundos | ✗ | No hay pickup ni lógica de invulnerabilidad en `Assets/Scripts/` ni en `Assets/Prefabs/Pickeable/` |
| K4 | Reward: monedas para el shop | ✗ | No hay monedas. Las llaves (`KeyScript`) son la parte opcional del ítem |

### Sonido

| #  | Requisito | Estado | Evidencia |
|----|-----------|--------|-----------|
| S1 | AudioMixer con Master, Music, FX y UI | ✓ | `AudioMixer.mixer` con los grupos `Master`, `Background`, `SFX` y `UI` |
| S2 | Al menos 3 grupos con sliders en Settings | ✓ | `AudioMixerScript.cs:18-21` y 4 sliders en `Canvas Menu 1.prefab`. `Panel Setings` lo abre `MenuAccion.OnButtonVolumeClick` (`MenuAcctions.cs:58`) |
| S3 | Toda acción del juego se refleja en sonido | Parcial | No suenan el salto (`MovimentPlayer.cs:68`) ni la caminata del enemigo, y el ataque enemigo reutiliza el sonido de muerte |

### Datos

| #  | Requisito | Estado | Evidencia |
|----|-----------|--------|-----------|
| D1 | Todas las configuraciones en ScriptableObject | Parcial | `VolumenValues` se lee en `AudioMixerScript.cs:35-38`. `PlayerSO` solo se escribe (`AbstractPlayerstats.cs:24` y `:34`), y en métodos que no corren (`AbstractPlayerstats.cs:17`); vida, daño, velocidad y llaves para ganar quedan hardcodeados |
| D2 | Datos de partida en PlayerPrefs | ✗ | No hay ninguna llamada a `PlayerPrefs` en `Assets/Scripts/` |

### Extras

| #  | Extra | Estado | Evidencia |
|----|-------|--------|-----------|
| X1 | Doble salto | ✓ | `MovimentPlayer.cs:61-77`, habilitado por `ExtraJumpScript` |
| X2 | Triple salto por power up | ✗ | No está implementado |
| X3 | Tienda con monedas | ✗ | No está implementado |
| X4 | PlayFab | ✗ | No está implementado |
| X5 | Multijugador local | ✗ | No está implementado |

## 2. Cumplimiento de Pautas de Cursada

| ID | Pauta | Estado | Evidencia |
|----|-------|--------|-----------|
| P1 | Unity 6000.3.21f1 | ✓ | `ProjectSettings/ProjectVersion.txt` dice `6000.3.21f1` |
| P2 | Repositorio público | ✓ | El repositorio es público (revisado el 2026-11-16) |
| P3 | Nombre del repo | ✓ | `TP08_C1_Moreno_KosmicKnight` |
| P4 | Código en inglés | ✗ | Hay identificadores en español: las clases `ClicksInteraccion`, `MenuAccion`, `VolumenValues` y `CamaraFollowing`, y las locales `direccion` (`ParallaxFollowCamara.cs:20`) y `origen` (`InteractionsEnemy.cs:81`) |
| P5 | Un repo por TP, sin branches | ✓ | Solo `main`, 22 commits, sin carpetas de otro TP |

## 3. Estructura de carpetas

| Carpeta esperada | Encontrada | Observación |
|------------------|------------|-------------|
| `Assets/Scenes/` | ✓ | |
| `Assets/Scripts/` | ✓ | Subcarpetas `Gameplay/`, `Main Menu/`, `ScriptableObjects/` |
| `Assets/Prefabs/` | ✓ | |
| `Assets/Art/Sprites/` | ✗ | Los sprites están en `Art/Player/`, `Art/Enemy/`, `Art/Map/`, `Art/Pikeables/`, `Art/TIles/` |
| `Assets/Art/Animations/` | ✗ | Las animaciones están en `Art/Player/Animations/` y `Art/Enemy/Golem/animation golem/` |
| `Assets/Art/Audio/` | ✓ | Incluye el `.mixer` |
| `Assets/Data/` | ✗ | Los `.asset` de SO están en `Assets/Scripts/ScriptableObjects/` |

Archivos mal ubicados:

- `Assets/Scripts/ScriptableObjects/PlayerSO.asset` tendría que estar en `Assets/Data/`.
- `Assets/Scripts/ScriptableObjects/VolumenValues.asset` tendría que estar en `Assets/Data/`.
- `Assets/_Recovery/` con `0.unity`, `0 (1).unity` y `0 (2).unity`: son escenas de recuperación que quedaron versionadas.

Otras cosas: `Assets/Prefabs/Canvas Menu.prefab` no se usa en ninguna escena (solo `Canvas Menu 1.prefab`). `Assets/Art/Bloodlines UI/` y `Assets/TextMesh Pro/` son paquetes importados y no los corregí. `PlayerSO.asset` tiene los campos `Jumps` y `Gold`, que ya no existen en `PlayerSO.cs`.

## 4. Qué le falta

- Barra de vida para el enemigo (E2).
- Partículas cuando muere el enemigo (E3).
- Pickup de invulnerabilidad (K3) y monedas (K4).
- Que el pickup de daño aumente `Damage` (K2).
- Sonido de salto y un sonido de ataque propio del enemigo (J6, E4, S3).
- Guardar datos en `PlayerPrefs` (llaves, mejor tiempo, volúmenes) (D2).
- Que `PlayerSO` sea la fuente de los valores iniciales y que la base `AbstractPlayerstats` se ejecute de verdad (D1).
- Mover al jugador y al enemigo con el Rigidbody2D en `FixedUpdate`.
- Renombrar los identificadores en español (P4) y hacer coincidir el nombre de clase y de archivo en `MenuAcctions.cs` y `Camara Following.cs`.

## 5. Hallazgos de código

### Error (6)
- `Assets/Scripts/Main Menu/MenuAcctions.cs:5` la clase `MenuAccion` está en un archivo que se llama distinto. Unity lo compila pero tira un warning: renombrá el archivo o la clase para que coincidan.
- `Assets/Scripts/Gameplay/Extra Panels/Camara Following.cs:3` la clase `CamaraFollowing` está en un archivo que se llama distinto. Unity lo compila pero tira un warning: renombrá el archivo o la clase para que coincidan.
- `Assets/Scripts/Gameplay/Player/AbstractPlayerstats.cs:22` Escribís el SO desde el MonoBehaviour en vez de usarlo como fuente de datos (D1).
- `Assets/Scripts/Gameplay/Player/MovimentPlayer.cs:68` El salto no tiene sonido (J6, S3).
- `Assets/Scripts/Gameplay/Enemy/StatsEnemy.cs:11` El enemigo no tiene barra de vida (E2).
- `Assets/Scripts/Gameplay/Enemy/StatsEnemy.cs:37` La muerte del enemigo no tiene partículas (E3).

### Bug (5)
- `Assets/Scripts/Gameplay/Player/AbstractPlayerstats.cs:17` `Start` y `Update` son privados en la base, quedan ocultos por los de `MovimentPlayer` y nunca corren.
- `Assets/Scripts/Gameplay/Enemy/InteractionsEnemy.cs:71` Un golem muerto puede seguir disparando `StartAtack`.
- `Assets/Scripts/Gameplay/Enemy/StatsEnemy.cs:57` `TakeDamage` no chequea `isDead` y vuelve a llamar a `Die()`.
- `Assets/Scripts/Gameplay/Enemy/StatsEnemy.cs:82` El ataque reproduce `deadSound`.
- `Assets/Scripts/Main Menu/ClicksInteraccion.cs:26` Pisa en cada frame el `Time.timeScale = 0` del panel de victoria.

### Warning (14)
- `Assets/Scripts/Gameplay/Player/AbstractPlayerstats.cs:5` Campos de stats `public`.
- `Assets/Scripts/Gameplay/Player/MovimentPlayer.cs:14` `[SerializeField] public` mutables.
- `Assets/Scripts/Gameplay/Player/MovimentPlayer.cs:51` `transform.position` con Rigidbody2D en `Update`.
- `Assets/Scripts/Gameplay/Player/AtackPlayer.cs:7` El estado del power up vive en un pickup que se destruye.
- `Assets/Scripts/Gameplay/Enemy/abstractEnemy.cs:6` Campos `[SerializeField] public`.
- `Assets/Scripts/Gameplay/Enemy/InteractionsEnemy.cs:18` `LayerMask.NameToLayer` con strings mágicos.
- `Assets/Scripts/Gameplay/Enemy/InteractionsEnemy.cs:22` `FindObjectOfType` en cada golpe.
- `Assets/Scripts/Gameplay/Enemy/InteractionsEnemy.cs:45` `FindObjectOfType` en cada impacto de proyectil.
- `Assets/Scripts/Gameplay/Enemy/InteractionsEnemy.cs:114` `transform.Translate` con Rigidbody2D en `Update`.
- `Assets/Scripts/Gameplay/Enemy/StatsEnemy.cs:43` `GameObject.Find("Player")`.
- `Assets/Scripts/Gameplay/Ui Elements/HealBarPlayer.cs:9` La vida vive en el `Slider` de la UI.
- `Assets/Scripts/Gameplay/Extra Panels/Camara Following.cs:14` `Lerp` con factor fijo, depende de los FPS.
- `Assets/Scripts/Main Menu/AudioMixerScript.cs:47` Los volúmenes se guardan en un SO y no persisten en la build.
- `Assets/Scripts/Gameplay/Pickeable/AbstractPickeable.cs:19` `FindObjectOfType` en cada pickup.

### Suggestion (17)
- `Assets/Scripts/Gameplay/Enemy/abstractEnemy.cs:3` El nombre de la clase no está en PascalCase y la clase no es abstract.
- `Assets/Scripts/Gameplay/Enemy/abstractEnemy.cs:19` `Update` vacío.
- `Assets/Scripts/Gameplay/Enemy/InteractionsEnemy.cs:30` El bloque de flip está copiado 4 veces.
- `Assets/Scripts/Gameplay/Enemy/StatsEnemy.cs:1` `using Unity.VisualScripting` sin uso.
- `Assets/Scripts/Gameplay/Player/MovimentPlayer.cs:40` Número mágico 3 para ganar.
- `Assets/Scripts/Gameplay/Player/MovimentPlayer.cs:81` Parámetros del Animator como strings.
- `Assets/Scripts/Gameplay/Player/AtackPlayer.cs:43` `CDAtack` pisado con un literal.
- `Assets/Scripts/Gameplay/Player/AtackPlayer.cs:46` Llamada a `ShootInAtackPlayer` que nunca dispara.
- `Assets/Scripts/Gameplay/Player/ShootingPlayer.cs:1` `using System` sin uso.
- `Assets/Scripts/Gameplay/Ui Elements/HealBarPlayer.cs:1` `Unity.Mathematics` solo para `math.sign`.
- `Assets/Scripts/Gameplay/Ui Elements/HealBarPlayer.cs:28` Vida máxima 7 hardcodeada.
- `Assets/Scripts/Gameplay/Ui Elements/KeyCount.cs:6` `lifeCountText` muestra llaves y se actualiza en cada frame.
- `Assets/Scripts/Main Menu/MenuAcctions.cs:55` Nombres de escena como strings.
- `Assets/Scripts/Main Menu/MenuAcctions.cs:71` El nombre `OnButtonHTPClick` no describe lo que hace.
- `Assets/Scripts/Main Menu/BackgroundParalax.cs:1` `using System` sin uso.
- `Assets/Scripts/Gameplay/Pickeable/AbstractPickeable.cs:33` `Destroy` duplicado con `KeyScript`.
- `Assets/Scripts/Gameplay/Pickeable/HealingPickScript.cs:5` La lógica de colisión está copiada en los 4 pickups.

## 6. Recomendaciones

1. Agregale barra de vida al Golem (un Slider en World Space hijo del prefab, actualizado en `TakeDamage`) y un `ParticleSystem` que se instancie en `Die()` (E2, E3).
2. Creá el pickup de invulnerabilidad con una corrutina que ignore el daño durante x segundos, y monedas que se sumen y se guarden en `PlayerPrefs` (K3, K4, D2).
3. Hacé que el pickup de daño sume a `Damage` (K2).
4. Agregá el sonido de salto y un AudioSource propio para el ataque del enemigo (J6, E4, S3).
5. Corregí los 5 bugs: `isDead` en `TakeDamage` y en el ataque, `Start`/`Update` de la base como `protected virtual`, y el manejo de `Time.timeScale` en `ClicksInteraccion`.
6. Invertí el flujo de `PlayerSO`: que el jugador lea de ahí vida, daño, salto y velocidad, y llevá las llaves para ganar a un SO del nivel (D1).
7. Mové al jugador y al enemigo con `rb.linearVelocity` en `FixedUpdate` y reemplazá `FindObjectOfType` y `GameObject.Find` por referencias.
8. Pasá a inglés `ClicksInteraccion`, `MenuAccion`, `VolumenValues`, `CamaraFollowing`, `direccion` y `origen` (P4). Renombrá `MenuAcctions.cs` y `Camara Following.cs` desde Unity para que coincidan con su clase, así conservás el `.meta`.
9. Reorganizá las carpetas (`Art/Sprites/`, `Art/Animations/`, `Data/`) y borrá `Assets/_Recovery/`.
