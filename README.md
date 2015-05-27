# Health

*Health* extension for Unity. Use it to increase/decrease game object's health.

Licensed under MIT license. See LICENSE file in the project root folder.   
Extensions with version below 1.0.0 are considered to be pre/alpha and may not work properly.

![Health](/Resources/cover_screenshot.png?raw=true)

## Features

* Add/remove health
* Execute callback on health change

## Resources

* [Blog post](https://bartlomiejwolk.wordpress.com/2015/05/27/health/)

## Quick Start

1. Clone or download (with the *Download* button) the repository into the *Assets* folder.
2. Select game object in the hierarchy window that should have health and from
   the *Component* menu select *Health -> Health* to add health component to the 
   selected game object.
3. Select game object in the hierarchy window that should apply damage and from
   the *Component* menu select *Health -> Damage* to add damage component to the 
   selected game object. 
4. *Damage* component has a `ApplyDamage(RaycastHit)` method. In play mode,
   call it to apply specified damage to the game object with the *Health*
   component.

## Help

Just create an issue and I'll do my best to help.

## Contributions

Pull requests, ideas, questions or any feedback at all are welcome.

See also: [Unity extensions as git submodules](http://wp.me/p56Vqs-6o)

## Versioning

Example: `v0.2.3f1`

- `0` Introduces breaking changes.
- `2` Major release. Adds new features.
- `3` Minor release. Bug fixes and refactoring.
- `f1` Quick fix.

## Thanks
