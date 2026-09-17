
using System;
using System.Collections;
using UnityEngine.Internal;
using CustomMath;

public class MyTransform : IEnumerable
{
   //private class Enumerator : IEnumerator
   //{
   //    private MyTransform outer;
   //
   //    private int currentIndex = -1;
   //
   //    public object Current => outer.GetChild(currentIndex);
   //
   //    internal Enumerator(MyTransform outer)
   //    {
   //        this.outer = outer;
   //    }
   //
   //    public bool MoveNext()
   //    {
   //        int childCount = outer.childCount;
   //        return ++currentIndex < childCount;
   //    }
   //
   //    public void Reset()
   //    {
   //        currentIndex = -1;
   //    }
   //}

    //
    // Resumen:
    //     The world space position of the Transform.
    public Vec3 position
    {
        get
        {

        }
        set
        {
            
        }
    }

    //
    // Resumen:
    //     Position of the transform relative to the parent transform.
    public Vec3 localPosition
    {
        get
        {
            
            
            
            
            

            
            
        }
        set
        {
            
            
            
            
            

            
        }
    }

    //
    // Resumen:
    //     The rotation as Euler angles in degrees.
    public Vec3 eulerAngles
    {
        get
        {
           
        }
        set
        {
            
        }
    }

    //
    // Resumen:
    //     The rotation as Euler angles in degrees relative to the parent transform's rotation.
    public Vec3 localEulerAngles
    {
        get
        {
            
        }
        set
        {
            
        }
    }

    //
    // Resumen:
    //     The red axis of the transform in world space.
    public Vec3 right
    {
        get
        {
            
        }
        set
        {
            
        }
    }

    //
    // Resumen:
    //     The green axis of the transform in world space.
    public Vector3 up
    {
        get
        {
            return rotation * Vector3.up;
        }
        set
        {
            rotation = Quaternion.FromToRotation(Vector3.up, value);
        }
    }

    //
    // Resumen:
    //     Returns a normalized vector representing the blue axis of the transform in world
    //     space.
    public Vec3 forward
    {
        get
        {
           
        }
        set
        {
           
        }
    }

    //
    // Resumen:
    //     A Quaternion that stores the rotation of the Transform in world space.
    public Quat rotation
    {
        get
        {
            
            
            
            
            

            
            
        }
        set
        {
            
            
            
            
            

            
        }
    }

    //
    // Resumen:
    //     The rotation of the transform relative to the transform rotation of the parent.
    public Quat localRotation
    {
        get
        {
            
            
            
            
            

            
            
        }
        set
        {
            
            
            
            
            

            
        }
    }

    //
    // Resumen:
    //     The scale of the transform relative to the GameObjects parent.
    public Vec3 localScale
    {
        get
        {
            
            
            
            
            

            
            
        }
        set
        {
           
           
           
           
           

           
        }
    }

    //
    // Resumen:
    //     The parent of the transform.
    public MyTransform parent
    {
        get
        {
            
        }
        set
        {
            
            
            
            

            
        }
    }

    //
    // Resumen:
    //     Matrix that transforms a point from world space into local space (Read Only).
    public Mat4x4 worldToLocalMatrix
    {
        get
        {
            
            
            
            
            

            
            
        }
    }

    //
    // Resumen:
    //     Matrix that transforms a point from local space into world space (Read Only).
    public Mat4x4 localToWorldMatrix
    {
        get
        {
            
            
            
            
            

            
            
        }
    }

    //
    // Resumen:
    //     Returns the topmost transform in the hierarchy.
    public MyTransform root => GetRoot();

    //
    // Resumen:
    //     The number of children the parent Transform has.
    public int childCount
    {
        
        get
        {
           
           
           
           
           

           
        }
    }

    //
    // Resumen:
    //     The global scale of the object (Read Only).
    public Vec3 lossyScale
    {
        get
        {
           
           
           
           
           

           
           
        }
    }

    //
    // Resumen:
    //     Has the transform changed since the last time the flag was set to 'false'?
    
    public bool hasChanged
    {
        get
        {
            
            
            
            
            

            
        }
        set
        {
           
           
           
           
           

           
        }
    }

    //
    // Resumen:
    //     The transform capacity of the transform's hierarchy data structure.
    public int hierarchyCapacity
    {
        get
        {
            
        }
        set
        {
           
        }
    }

    //
    // Resumen:
    //     The number of transforms in the transform's hierarchy data structure.
    public int hierarchyCount => ;

    
    private MyTransform GetParent()
    {
        
        
        
        
        

        
    }

    //
    // Resumen:
    //     Set the parent of the transform.
    //
    // Parámetros:
    //   parent:
    //     The parent Transform to use.
    //
    //   worldPositionStays:
    //     If true, the parent-relative position, scale and rotation are modified such that
    //     the object keeps the same world space position, rotation and scale as before.
    //
    //
    //   p:
    public void SetParent(MyTransform p)
    {
        
    }

    //
    // Resumen:
    //     Set the parent of the transform.
    //
    // Parámetros:
    //   parent:
    //     The parent Transform to use.
    //
    //   worldPositionStays:
    //     If true, the parent-relative position, scale and rotation are modified such that
    //     the object keeps the same world space position, rotation and scale as before.
    //
    //
    //   p:
   
    public void SetParent(MyTransform parent, bool worldPositionStays)
    {
        
        
        
        
        

        
    }

    //
    // Resumen:
    //     Sets the world space position and rotation of the Transform component.
    //
    // Parámetros:
    //   position:
    //     The world space position to apply to the transform.
    //
    //   rotation:
    //     The world space rotation to apply to the transform.
    public void SetPositionAndRotation(Vec3 position, Quat rotation)
    {
        
        
        
        
        

        
    }

    //
    // Resumen:
    //     Sets the position and rotation of the Transform component in local space (i.e.
    //     relative to its parent transform).
    //
    // Parámetros:
    //   localPosition:
    //     The local space position to apply to the transform.
    //
    //   localRotation:
    //     The local space rotation to apply to the transform.
    public void SetLocalPositionAndRotation(Vec3 localPosition, Quat localRotation)
    {
        
        
        
        
        

        
    }

    public void GetPositionAndRotation(out Vec3 position, out Quat rotation)
    {
        
        
        
        
        

        
    }

    public void GetLocalPositionAndRotation(out Vec3 localPosition, out Quat localRotation)
    {
        
        
        
        
        

        
    }

    //
    // Resumen:
    //     Moves the transform along its x, y, and z axes by the values of the translation
    //     parameter's x, y, and z components respectively.
    //
    // Parámetros:
    //   translation:
    //     The amount by which to move the Transform.
    //
    //   relativeTo:
    //     The coordinate system in which to apply the translation.
    public void Translate(Vec3 translation, [DefaultValue("Space.Self")] Space relativeTo)
    {
        
        
        
        
        
        
        
        
    }

    //
    // Resumen:
    //     Moves the transform along its x, y, and z axes by the values of the translation
    //     parameter's x, y, and z components respectively.
    //
    // Parámetros:
    //   translation:
    //     The amount by which to move the Transform.
    //
    //   relativeTo:
    //     The coordinate system in which to apply the translation.
    public void Translate(Vec3 translation)
    {

    }

    //
    // Resumen:
    //     Moves the transform by x along the x axis, y along the y axis, and z along the
    //     z axis.
    //
    // Parámetros:
    //   x:
    //     The amount by which to move the Transform on the x-axis.
    //
    //   y:
    //     The amount by which to move the Transform on the y-axis.
    //
    //   z:
    //     The amount by which to move the Transform on the z-axis.
    //
    //   relativeTo:
    //     The coordinate system in which the translation is applied.
    public void Translate(float x, float y, float z, [DefaultValue("Space.Self")] Space relativeTo)
    {

    }

    //
    // Resumen:
    //     Moves the transform by x along the x axis, y along the y axis, and z along the
    //     z axis.
    //
    // Parámetros:
    //   x:
    //     The amount by which to move the Transform on the x-axis.
    //
    //   y:
    //     The amount by which to move the Transform on the y-axis.
    //
    //   z:
    //     The amount by which to move the Transform on the z-axis.
    //
    //   relativeTo:
    //     The coordinate system in which the translation is applied.
    public void Translate(float x, float y, float z)
    {
        
    }

    //
    // Resumen:
    //     Moves the transform along its x, y, and z axes by the values of the translation
    //     parameter's x, y, and z components respectively.
    //
    // Parámetros:
    //   translation:
    //     The amount by which to move the Transform.
    //
    //   relativeTo:
    //     Defines the coordinate system used for the translation.
    public void Translate(Vec3 translation, MyTransform relativeTo)
    {
        
        
        
        
        
        
        
        
    }

    //
    // Resumen:
    //     Moves the transform by x along the x axis, y along the y axis, and z along the
    //     z axis.
    //
    // Parámetros:
    //   x:
    //     The amount by which to move the Transform on the x-axis.
    //
    //   y:
    //     The amount by which to move the Transform on the y-axis.
    //
    //   z:
    //     The amount by which to move the Transform on the z-axis.
    //
    //   relativeTo:
    //     Defines the coordinate system used for the translation.
    public void Translate(float x, float y, float z, MyTransform relativeTo)
    {
       
    }

    //
    // Resumen:
    //     Applies a rotation of eulerAngles.z degrees around the z-axis, eulerAngles.x
    //     degrees around the x-axis, and eulerAngles.y degrees around the y-axis (in that
    //     order).
    //
    // Parámetros:
    //   eulers:
    //     The rotation to apply in euler angles.
    //
    //   relativeTo:
    //     Determines whether to rotate the GameObject either locally to the GameObject
    //     or relative to the Scene in world space.
    public void Rotate(Vec3 eulers, [DefaultValue("Space.Self")] Space relativeTo)
    {
        
        
        
        
        
        
        
        
        
    }

    //
    // Resumen:
    //     Applies a rotation of eulerAngles.z degrees around the z-axis, eulerAngles.x
    //     degrees around the x-axis, and eulerAngles.y degrees around the y-axis (in that
    //     order).
    //
    // Parámetros:
    //   eulers:
    //     The rotation to apply in euler angles.
    public void Rotate(Vec3 eulers)
    {
        
    }

    //
    // Resumen:
    //     The implementation of this method applies a rotation of zAngle degrees around
    //     the z axis, xAngle degrees around the x axis, and yAngle degrees around the y
    //     axis (in that order).
    //
    // Parámetros:
    //   xAngle:
    //     Degrees to rotate the GameObject around the X axis.
    //
    //   yAngle:
    //     Degrees to rotate the GameObject around the Y axis.
    //
    //   zAngle:
    //     Degrees to rotate the GameObject around the Z axis.
    //
    //   relativeTo:
    //     Determines whether to rotate the GameObject either locally to the GameObject
    //     or relative to the Scene in world space.
    public void Rotate(float xAngle, float yAngle, float zAngle, [DefaultValue("Space.Self")] Space relativeTo)
    {
        
    }

    //
    // Resumen:
    //     The implementation of this method applies a rotation of zAngle degrees around
    //     the z axis, xAngle degrees around the x axis, and yAngle degrees around the y
    //     axis (in that order).
    //
    // Parámetros:
    //   xAngle:
    //     Degrees to rotate the GameObject around the X axis.
    //
    //   yAngle:
    //     Degrees to rotate the GameObject around the Y axis.
    //
    //   zAngle:
    //     Degrees to rotate the GameObject around the Z axis.
    public void Rotate(float xAngle, float yAngle, float zAngle)
    {
        
    }


    //
    // Resumen:
    //     Rotates the object around the given axis by the number of degrees defined by
    //     the given angle.
    //
    // Parámetros:
    //   axis:
    //     The axis to apply rotation to.
    //
    //   angle:
    //     The degrees of rotation to apply.
    //
    //   relativeTo:
    //     Determines whether to rotate the GameObject either locally to the GameObject
    //     or relative to the Scene in world space.
    public void Rotate(Vec3 axis, float angle, [DefaultValue("Space.Self")] Space relativeTo)
    {
        
        
        
        
        
        
        
        
    }

    //
    // Resumen:
    //     Rotates the object around the given axis by the number of degrees defined by
    //     the given angle.
    //
    // Parámetros:
    //   axis:
    //     The axis to apply rotation to.
    //
    //   angle:
    //     The degrees of rotation to apply.
    public void Rotate(Vec3 axis, float angle)
    {
        
    }

    //
    // Resumen:
    //     Rotates the transform about axis passing through point in world coordinates by
    //     angle degrees.
    //
    // Parámetros:
    //   point:
    //     The world-space point to rotate the target object around.
    //
    //   axis:
    //     The world-space axis to rotate the target object around. This vector does not
    //     need to be unit length.
    //
    //   angle:
    //     The angle to rotate, provided in degrees.
    public void RotateAround(Vec3 point, Vec3 axis, float angle)
    {
        
        
        
        
        
        
        
    }

    //
    // Resumen:
    //     Rotates the transform so the forward vector points at target's current position.
    //
    //
    // Parámetros:
    //   target:
    //     Object to point towards.
    //
    //   worldUp:
    //     Vector specifying the upward direction.
    public void LookAt(MyTransform target, [DefaultValue("Vector3.up")] Vec3 worldUp)
    {
        
        
        
        
    }

    //
    // Resumen:
    //     Rotates the transform so the forward vector points at target's current position.
    //
    //
    // Parámetros:
    //   target:
    //     Object to point towards.
    //
    //   worldUp:
    //     Vector specifying the upward direction.
    public void LookAt(MyTransform target)
    {
        
        
        
        
    }

    //
    // Resumen:
    //     Rotates the transform so the forward vector points at worldPosition.
    //
    // Parámetros:
    //   worldPosition:
    //     Point to look at.
    //
    //   worldUp:
    //     Vector specifying the upward direction.
    public void LookAt(Vec3 worldPosition, [DefaultValue("Vector3.up")] Vec3 worldUp)
    {

    }

    //
    // Resumen:
    //     Rotates the transform so the forward vector points at worldPosition.
    //
    // Parámetros:
    //   worldPosition:
    //     Point to look at.
    //
    //   worldUp:
    //     Vector specifying the upward direction.
    public void LookAt(Vec3 worldPosition)
    {
        
    }

    //
    // Resumen:
    //     Transforms direction from local space to world space.
    //
    // Parámetros:
    //   direction:
    public Vec3 TransformDirection(Vec3 direction)
    {
        
        
        
        
        

        
        
    }

    //
    // Resumen:
    //     Transforms direction x, y, z from local space to world space.
    //
    // Parámetros:
    //   x:
    //
    //   y:
    //
    //   z:
    public Vec3 TransformDirection(float x, float y, float z)
    {
        
    }

    public void TransformDirections(ReadOnlySpan<Vec3> directions, Span<Vec3> transformedDirections)
    {
        
    }

    public void TransformDirections(Span<Vec3> directions)
    {
        
    }

    //
    // Resumen:
    //     Transforms a direction from world space to local space. The opposite of Transform.TransformDirection.
    //
    //
    // Parámetros:
    //   direction:
    public Vec3 InverseTransformDirection(Vec3 direction)
    {
        
    }

    //
    // Resumen:
    //     Transforms the direction x, y, z from world space to local space. The opposite
    //     of Transform.TransformDirection.
    //
    // Parámetros:
    //   x:
    //
    //   y:
    //
    //   z:
    public Vec3 InverseTransformDirection(float x, float y, float z)
    {
        
    }


    public void InverseTransformDirections(ReadOnlySpan<Vec3> directions, Span<Vec3> transformedDirections)
    {
        
    }

    public void InverseTransformDirections(Span<Vec3> directions)
    {
       
    }

    //
    // Resumen:
    //     Transforms vector from local space to world space.
    //
    // Parámetros:
    //   vector:
    //     The vector to transform, in local space.
    //
    // Devuelve:
    //     The transformed vector, in world space.
    public Vec3 TransformVector(Vec3 vector)
    {
        
        
        
        
        

        
        
    }

    //
    // Resumen:
    //     Transforms vector x, y, z from local space to world space.
    //
    // Parámetros:
    //   x:
    //     The x component of the vector to transform, in local space.
    //
    //   y:
    //     The y component of the vector to transform, in local space.
    //
    //   z:
    //     The z component of the vector to transform, in local space.
    //
    // Devuelve:
    //     The transformed vector, in world space.
    public Vec3 TransformVector(float x, float y, float z)
    {
        
    }


    public void TransformVectors(ReadOnlySpan<Vec3> vectors, Span<Vec3> transformedVectors)
    {
        
    }

    public void TransformVectors(Span<Vec3> vectors)
    {
        
    }

    //
    // Resumen:
    //     Transforms a vector from world space to local space. The opposite of Transform.TransformVector.
    //
    //
    // Parámetros:
    //   vector:
    //     The vector to transform, in world space.
    //
    // Devuelve:
    //     The transformed vector, in local space.
    public Vec3 InverseTransformVector(Vec3 vector)
    {
        
    }

    //
    // Resumen:
    //     Transforms the vector x, y, z from world space to local space. The opposite of
    //     Transform.TransformVector.
    //
    // Parámetros:
    //   x:
    //     The x component of the vector to transform, in world space.
    //
    //   y:
    //     The y component of the vector to transform, in world space.
    //
    //   z:
    //     The z component of the vector to transform, in world space.
    //
    // Devuelve:
    //     The transformed vector, in local space.
    public Vec3 InverseTransformVector(float x, float y, float z)
    {
        
    }

    public void InverseTransformVectors(ReadOnlySpan<Vec3> vectors, Span<Vec3> transformedVectors)
    {

    }

    public void InverseTransformVectors(Span<Vec3> vectors)
    {
       
    }

    //
    // Resumen:
    //     Transforms position from local space to world space.
    //
    // Parámetros:
    //   position:
    public Vec3 TransformPoint(Vec3 position)
    {
       
    }

    //
    // Resumen:
    //     Transforms the position x, y, z from local space to world space.
    //
    // Parámetros:
    //   x:
    //
    //   y:
    //
    //   z:
    public Vec3 TransformPoint(float x, float y, float z)
    {
        
    }

    
    public void TransformPoints(ReadOnlySpan<Vec3> positions, Span<Vec3> transformedPositions)
    {
        
    }

    public void TransformPoints(Span<Vec3> positions)
    {
        
    }

    //
    // Resumen:
    //     Transforms position from world space to local space.
    //
    // Parámetros:
    //   position:
    public Vec3 InverseTransformPoint(Vec3 position)
    {
       
    }

    //
    // Resumen:
    //     Transforms the position x, y, z from world space to local space.
    //
    // Parámetros:
    //   x:
    //
    //   y:
    //
    //   z:
    public Vec3 InverseTransformPoint(float x, float y, float z)
    {
        
    }

    public void InverseTransformPoints(ReadOnlySpan<Vec3> positions, Span<Vec3> transformedPositions)
    {
        
    }

    public void InverseTransformPoints(Span<Vec3> positions)
    {
        InverseTransformPoints(positions, positions);
    }

    private MyTransform GetRoot()
    {
        
    }

    //
    // Resumen:
    //     Unparents all of the target object's children.
   
    public void DetachChildren()
    {
       
    }

    //
    // Resumen:
    //     Move the transform to the start of the local transform list.
    public void SetAsFirstSibling()
    {
        
    }

    //
    // Resumen:
    //     Move the transform to the end of the local transform list.
    public void SetAsLastSibling()
    {
       
    }

    //
    // Resumen:
    //     Sets the sibling index.
    //
    // Parámetros:
    //   index:
    //     Index to set.
    public void SetSiblingIndex(int index)
    {
       
    }


    //
    // Resumen:
    //     Gets the index of this Transform, relative to its siblings.
    //
    // Devuelve:
    //     The index of this Transform, relative to its siblings.
    public int GetSiblingIndex()
    {
      
    }

    private unsafe MyTransform FindRelativeTransformWithPath(string path, [DefaultValue("false")] bool isActiveOnly)
    {
        
    }

    //
    // Resumen:
    //     Finds a child by name n and returns it.
    //
    // Parámetros:
    //   n:
    //     The search string, either the name of an immediate child or a hierarchy path
    //     for finding a descendent.
    //
    // Devuelve:
    //     The found child transform. Null if child with matching name isn't found.
    public MyTransform Find(string n)
    {
        
    }


    //
    // Resumen:
    //     Is this transform a child of parent?
    //
    // Parámetros:
    //   parent:
    
    public bool IsChildOf([NotNull] MyTransform parent)
    {
        
    }

    public IEnumerator GetEnumerator()
    {
        
    }
    
    //
    // Resumen:
    //     Returns a transform child by index.
    //
    // Parámetros:
    //   index:
    //     Index of the child transform to return. Must be smaller than Transform.childCount.
    //
    //
    // Devuelve:
    //     Transform child by index.
    
    public MyTransform GetChild(int index)
    {
        
    }
}


